using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Cryptographies;
using Cryptographies.Objects;

namespace Crypto_UI
{
    public partial class EnigmaPage : Page
    {
        static List<int> Walzen = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        static List<char> reference = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public EnigmaPage()
        {
            InitializeComponent();
            PopulateWalzen();
            PopulateSteckerbrett();

        }

        #region Grundstellung
        private void Grundstellung1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Grundstellung1.IsInitialized)
            {
                Grundstellung1Value.Text = reference[((int)Grundstellung1.Value) - 1].ToString();

            }
        }
        private void Grundstellung2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Grundstellung2.IsInitialized)
            {
                Grundstellung2Value.Text = reference[((int)Grundstellung2.Value) - 1].ToString();

            }
        }

        private void Grundstellung3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Grundstellung3.IsInitialized)
            {
                Grundstellung3Value.Text = reference[((int)Grundstellung3.Value) - 1].ToString();
            }
        }

        private void ResetGrundstellung()
        {
            Grundstellung1.Value = 1;
            Grundstellung2.Value = 1;
            Grundstellung3.Value = 1;
        }
        #endregion

        //This region contains all functions pertaining to the rotors
        #region Walzen
        private void WalzenLage3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (WalzenLage1.SelectedItem != null && WalzenLage2.SelectedItem != null)
            {
                //Verify no other walzen has the chosen rotor already selected
                if (WalzenLage3.SelectedItem.ToString() == WalzenLage2.SelectedItem.ToString() && WalzenLage2.SelectedItem.ToString() != "-" ||
                    WalzenLage3.SelectedItem.ToString() == WalzenLage1.SelectedItem.ToString() && WalzenLage1.SelectedItem.ToString() != "-")
                {
                    WalzenLage3.SelectedIndex = WalzenLage3.Items.IndexOf("-");
                }
            }
        }

        private void WalzenLage1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (WalzenLage2.SelectedItem != null && WalzenLage3.SelectedItem != null)
            {
                //Verify no other walzen has the chosen rotor already selected
                if (WalzenLage1.SelectedItem.ToString() == WalzenLage2.SelectedItem.ToString() && WalzenLage2.SelectedItem.ToString() != "-" ||
                    WalzenLage1.SelectedItem.ToString() == WalzenLage3.SelectedItem.ToString() && WalzenLage3.SelectedItem.ToString() != "-")
                {
                    WalzenLage1.SelectedIndex = WalzenLage1.Items.IndexOf("-");
                }
            }
        }

        private void WalzenLage2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (WalzenLage1.SelectedItem != null && WalzenLage3.SelectedItem != null)
            {
                //Verify no other walzen has the chosen rotor already selected
                if (WalzenLage2.SelectedItem.ToString() == WalzenLage3.SelectedItem.ToString() && WalzenLage3.SelectedItem.ToString() != "-" ||
                    WalzenLage2.SelectedItem.ToString() == WalzenLage1.SelectedItem.ToString() && WalzenLage1.SelectedItem.ToString() != "-")
                {
                    WalzenLage2.SelectedIndex = WalzenLage2.Items.IndexOf("-");
                }
            }
        }

        public void PopulateWalzen()
        {
            WalzenLage1.Items.Add("-");
            WalzenLage1.SelectedIndex = 0;
            WalzenLage2.Items.Add("-");
            WalzenLage2.SelectedIndex = 0;
            WalzenLage3.Items.Add("-");
            WalzenLage3.SelectedIndex = 0;

            foreach (var rotor in Walzen)
            {
                WalzenLage1.Items.Add(rotor);
                WalzenLage2.Items.Add(rotor);
                WalzenLage3.Items.Add(rotor);
            }

            Umkehrwalzen.Items.Add("-");
            Umkehrwalzen.SelectedIndex = 0;
            Umkehrwalzen.Items.Add("B");
            Umkehrwalzen.Items.Add("C");
        }

        public void ResetWalzen()
        {
            WalzenLage1.SelectedIndex = WalzenLage1.Items.IndexOf("-");
            WalzenLage2.SelectedIndex = WalzenLage2.Items.IndexOf("-");
            WalzenLage3.SelectedIndex = WalzenLage3.Items.IndexOf("-");
            Umkehrwalzen.SelectedIndex = Umkehrwalzen.Items.IndexOf("-");
        }
        #endregion

        #region buttons
        private void ProcessShift_Click(object sender, RoutedEventArgs e)
        {
            string userin = UserInput.Text.ToUpper();
            EnigmaInput input = ProcessInput();

            Output.Text = Enigma.Encode(userin, input);

        }

        private void Decode_Click(object sender, RoutedEventArgs e)
        {
            
            string userin = UserInput.Text.ToUpper();
            EnigmaInput input = ProcessInput();
            
            Output.Text = Enigma.Decode(userin, input);
        }

        private EnigmaInput ProcessInput()
        {

            List<TextBlock> Connections = new List<TextBlock> { Conn0, Conn1, Conn2, Conn3, Conn4, Conn5, Conn6, Conn7, Conn8, Conn9,
                Conn10, Conn11, Conn12, Conn13, Conn14, Conn15, Conn16, Conn17, Conn18, Conn19 };

            //Gather connections on the plugboard
            Dictionary<char, char> steckerbrett = new Dictionary<char, char>();
            for (int i = 0; i < Connections.Count; i++)
            {
                if (Connections[i].Text != " _" && Connections[i].Text != "_ ")
                {
                    steckerbrett.Add(Char.Parse(Connections[i].Text.Trim()), Char.Parse(Connections[i + 1].Text.Trim()));
                    steckerbrett.Add(Char.Parse(Connections[i + 1].Text.Trim()), Char.Parse(Connections[i].Text.Trim()));
                    i++;
                }
            }
            EnigmaInput input = new EnigmaInput()
            {
                //Gather the starting positions for the rotors
                Grundstellung = new List<int>()
                {
                    reference.IndexOf(Char.Parse(Grundstellung1Value.Text)),
                    reference.IndexOf(Char.Parse(Grundstellung2Value.Text)),
                    reference.IndexOf(Char.Parse(Grundstellung3Value.Text))
                },
                //Gather selected rotors
                Walzenlage = new List<int>()
                {
                    Int32.Parse(WalzenLage1.SelectedItem.ToString()),
                    Int32.Parse(WalzenLage2.SelectedItem.ToString()),
                    Int32.Parse(WalzenLage3.SelectedItem.ToString())
                },
                UmkherwalzeChoice = Char.Parse(Umkehrwalzen.SelectedItem.ToString()),
                Steckerbrett = steckerbrett
            };

            return input;
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            ResetWalzen();
            ResetGrundstellung();
            ResetStecker();
            UserInput.Text = "Message";
            Output.Text = "Result Text";
        }
        #endregion

        //Methods to handle user changes to the Steckerbrett settings
        #region Steckerbrett
        private void Q_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(Q);
        }

        private void W_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(W);
        }

        private void E_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(E);
        }

        private void R_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(R);
        }

        private void T_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(T);
        }

        private void Z_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(Z);
        }

        private void U_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(U);
        }

        private void I_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(I);
        }

        private void O_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(O);
        }

        private void A_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(A);
        }

        private void S_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(S);
        }

        private void D_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(D);
        }

        private void F_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(F);
        }

        private void G_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(G);
        }

        private void H_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(H);
        }

        private void J_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(J);
        }

        private void K_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(K);
        }

        private void P_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(P);
        }

        private void Y_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(Y);
        }

        private void X_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(X);
        }

        private void C_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(C);
        }

        private void V_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(V);
        }

        private void B_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(B);
        }

        private void N_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(N);
        }

        private void M_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(M);
        }

        private void L_DropDownClosed(object sender, EventArgs e)
        {
            DecideSteckerAction(L);
        }
        #endregion


        #region SteckerbrettFunctions

        //Reset all Steckerbrett comboboxes and connection strings
        private void ResetStecker()
        {
            List<ComboBox> stecker = new List<ComboBox> { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z };
            List<TextBlock> Connections = new List<TextBlock> { Conn0, Conn1, Conn2, Conn3, Conn4, Conn5, Conn6, Conn7, Conn8, Conn9,
                Conn10, Conn11, Conn12, Conn13, Conn14, Conn15, Conn16, Conn17, Conn18, Conn19 };
            int counter = 0;
            foreach (var box in stecker)
            {
                box.SelectedIndex = 0;
            }
            foreach (var conn in Connections)
            {
                if (counter % 2 == 0)
                {
                    conn.Text = " _";
                }
                else
                {
                    conn.Text = "_ ";
                }
                counter++;
            }
        }

        //Reset Steckerbrett combobox and connection strings based on triggering combobox
        private void ResetStecker(ComboBox triggerBox)
        {
            List<ComboBox> stecker = new List<ComboBox> { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z };
            List<TextBlock> Connections = new List<TextBlock> { Conn0, Conn1, Conn2, Conn3, Conn4, Conn5, Conn6, Conn7, Conn8, Conn9,
                Conn10, Conn11, Conn12, Conn13, Conn14, Conn15, Conn16, Conn17, Conn18, Conn19 };
            foreach (var box in stecker)
            {
                //Verfiy the combobox has items has an item selected and that item is equal to the triggering combobox's name
                if (box.HasItems && box.SelectedItem != null && box.SelectedItem.ToString() == triggerBox.Name)
                {
                    box.SelectedIndex = 0;
                    break;
                }
            }
            for (var i = 0; i < Connections.Count; i++)
            {
                if (Connections[i].Text == triggerBox.Name + " " || Connections[i].Text == " " + triggerBox.Name)
                {
                    if (i % 2 == 0)
                    {
                        Connections[i].Text = " _";
                        Connections[i + 1].Text = "_ ";
                    }
                    else
                    {
                        Connections[i].Text = "_ ";
                        Connections[i - 1].Text = " _";
                    }
                }
            }

        }

        //Determines what action to take when a Steckerbrett combobox is changed
        private void DecideSteckerAction(ComboBox stecker)
        {
            //Determine if a connection has been set or removed
            if (stecker.SelectedItem == null)
            {
                stecker.SelectedIndex = 0;
            }
            else if (stecker.SelectedItem.ToString() != "-")
            {
                UpdateSteckerbrett(stecker);
            }
            else
            {
                ResetStecker(stecker);
            }
        }

        private void PopulateSteckerbrett()
        {
            List<ComboBox> stecker = new List<ComboBox> { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z };
            foreach (var box in stecker)
            {
                box.Items.Add("-"); //Buffer to indicate no connection
                box.SelectedIndex = 0;
                foreach (var letter in reference)
                {
                    if (box.Name != letter.ToString())
                    {
                        box.Items.Add(letter);
                    }
                }
            }
        }

        private void UpdateSteckerbrett(ComboBox triggerBox)
        {
            List<ComboBox> stecker = new List<ComboBox> { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z };

            //Check for an existing connection containing the triggering combobox OR the item that is selected
            if (CheckConnections(triggerBox, stecker)) {
                //Verify less than 10 connections exist or the triggering combobox is one that was part of a previous connection
                if (CheckConnectionCount(stecker))
                {
                    foreach (var box in stecker)
                    {
                        if (box != null)
                        {
                            //Verify combobox is not the triggering combobox and its name matches the one selected
                            if (box.Name != triggerBox.Name && box.Name == triggerBox.SelectedItem.ToString())
                            {
                                box.SelectedIndex = box.Items.IndexOf(Char.Parse(triggerBox.Name));
                            }
                        }
                    }
                }
                //Cancel the change to the triggering combobox
                else
                {
                    triggerBox.SelectedIndex = 0;
                }
            }
            //Update existing connections
            else
            {
                foreach(var box in stecker)
                {
                    if(box.SelectedItem.ToString() == triggerBox.Name || (box.Name != triggerBox.Name && box.SelectedItem.ToString() == triggerBox.SelectedItem.ToString()))
                    {
                        box.SelectedIndex = 0;
                    }
                    if(box.Name != triggerBox.Name && box.Name == triggerBox.SelectedItem.ToString())
                    {
                        box.SelectedIndex = box.Items.IndexOf(Char.Parse(triggerBox.Name));
                    }
                }
            }
            UpdateConnections(triggerBox);
        }

        //Checks the number of existing connections to determine if the maximum has been reached
        private bool CheckConnectionCount(List<ComboBox> stecker)
        {
            List<string> connections = new List<string>();
            foreach(var box in stecker)
            {
                if(box.SelectedItem.ToString() != "-" && !connections.Contains(box.Name))
                {
                        connections.Add(box.Name);
                }
            }
            if (connections.Count < 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Checks current connections and returns a boolean if a match is found
        private bool CheckConnections(ComboBox triggerBox, List<ComboBox> stecker)
        {
            foreach(var box in stecker)
            {
                if(box.SelectedItem.ToString() == triggerBox.Name || (box.Name != triggerBox.Name && box.SelectedItem.ToString() == triggerBox.SelectedItem.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        //Checks current connections and returns the connection containing the triggering combobox
        private TextBlock CheckConnections(ComboBox triggerBox, List<TextBlock> Connections)
        {
            TextBlock empty = new TextBlock();
            empty.Name = "Empty";
            foreach (var conn in Connections)
            {
                if (conn.Text == " " + triggerBox.Name || conn.Text == triggerBox.Name + " ")
                {
                    return conn;
                }
            }
            return empty;
        }

        private void UpdateConnections(ComboBox triggerBox)
        {
            List<TextBlock> Connections = new List<TextBlock> { Conn0, Conn1, Conn2, Conn3, Conn4, Conn5, Conn6, Conn7, Conn8, Conn9, 
                Conn10, Conn11, Conn12, Conn13, Conn14, Conn15, Conn16, Conn17, Conn18, Conn19 };
            TextBlock exisitng = CheckConnections(triggerBox, Connections);

            //Verify if the triggering combobox is part of an existing connection
            if (exisitng.Name.ToString() != "Empty")
            {
                int pos = Connections.IndexOf(exisitng);
                if(pos % 2 == 0)
                {
                    Connections[pos + 1].Text = triggerBox.SelectedItem.ToString();
                }
                else
                {
                    Connections[pos - 1].Text = triggerBox.SelectedItem.ToString();
                }
            }
            else
            {
                foreach (var conn in Connections)
                {
                    if (conn.Text == " _" || conn.Text == "_ ")
                    {
                        conn.Text = " " + triggerBox.Name;
                        var conn2 = Connections[Connections.IndexOf(conn) + 1];
                        conn2.Text = triggerBox.SelectedItem.ToString() + " ";
                        break;
                    }
                }
            }
        }

        private void RemoveConnection(ComboBox comboBox)
        {
            List<TextBlock> Connections = new List<TextBlock> { Conn0, Conn1, Conn2, Conn3, Conn4, Conn5, Conn6, Conn7, Conn8, Conn9,
                Conn10, Conn11, Conn12, Conn13, Conn14, Conn15, Conn16, Conn17, Conn18, Conn19 };
            int pos = 0;

            foreach(var conn in Connections)
            {
                pos = Connections.IndexOf(conn);
                if(pos % 2 == 0)
                {
                    conn.Text = " _";
                }
                else 
                {
                    conn.Text = "_ ";
                }
            }
        }


        #endregion
    }
}
