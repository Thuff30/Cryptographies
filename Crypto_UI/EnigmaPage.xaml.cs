using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crypto_UI
{
    public partial class EnigmaPage : Page
    {
        static List<int> Walzen = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        static char[] reference = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public EnigmaPage()
        {
            InitializeComponent();
            PopulateWalzen();
            PopulateSteckerbrett();

        }              

        private void Grundstellung1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

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
        }
        #endregion

        #region buttons
        private void ProcessShift_Click(object sender, RoutedEventArgs e)
        {
            string userin;
            List<int> grundstellung = new List<int>();
            List<int> walzenlage = new List<int>();
            char umkehrwalzenChoice;
            Dictionary<char, char> steckerbrett = new Dictionary<char, char>();
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

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

        public void ResetStecker()
        {
            List<ComboBox> stecker = new List<ComboBox> { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z };
            foreach (var box in stecker)
            {
                box.SelectedIndex = 0;
            }
        }

        public void ResetStecker(string triggerBox)
        {
            List<ComboBox> stecker = new List<ComboBox> { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z };
            foreach (var box in stecker)
            {
                //Verfiy the combobox has items has an item selected and that item is equal to the triggering combobox's name
                if (box.HasItems && box.SelectedItem != null && box.SelectedItem.ToString() == triggerBox)
                {
                    box.SelectedIndex = 0;
                    break;
                }
            }
        }

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
            else if (stecker.SelectedItem.ToString() == "-")
            {
                ResetStecker(stecker.Name.ToString());
            }
        }

        public void PopulateSteckerbrett()
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

        public void UpdateSteckerbrett(ComboBox triggerBox)
        {
            List<ComboBox> stecker = new List<ComboBox> { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z };

            //Verify less than 10 connections exist or the triggering combobox is one that was part of a previous connection
            if (Conn19.Text == "_ " || CheckConnections(triggerBox)) 
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
                        //Verify the combobox is not selected, is not the triggering combobox, is not not and the selected item is the triggering combobox
                        else if (box.Name != triggerBox.SelectedItem.ToString() && box.Name != triggerBox.Name && box.SelectedItem != null &&
                            box.SelectedItem.ToString() == triggerBox.Name)
                        {
                            box.SelectedIndex = 0;
                        }
                    }
                }

                AddConnections(triggerBox);
            }


        }

        public bool CheckConnections(ComboBox triggerBox)
        {
            List<TextBlock> Connections = new List<TextBlock> { Conn0, Conn1, Conn2, Conn3, Conn4, Conn5, Conn6, Conn7, Conn8, Conn9,
                Conn10, Conn11, Conn12, Conn13, Conn14, Conn15, Conn16, Conn17, Conn18, Conn19 };

            foreach(var conn in Connections)
            {
                if(conn.Text == triggerBox.Name || conn.Text == triggerBox.SelectedItem.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public void AddConnections(ComboBox triggerBox)
        {
            List<TextBlock> Connections = new List<TextBlock> { Conn0, Conn1, Conn2, Conn3, Conn4, Conn5, Conn6, Conn7, Conn8, Conn9, 
                Conn10, Conn11, Conn12, Conn13, Conn14, Conn15, Conn16, Conn17, Conn18, Conn19 };

            //Verify if the triggering combobox is part of an existing connection
            if (CheckConnections(triggerBox))
            {

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

        public void RemoveConnection(ComboBox comboBox)
        {
            List<TextBlock> Connections = new List<TextBlock> { Conn0, Conn1, Conn2, Conn3, Conn4, Conn5, Conn6, Conn7, Conn8, Conn9,
                Conn10, Conn11, Conn12, Conn13, Conn14, Conn15, Conn16, Conn17, Conn18, Conn19 };

            foreach(var conn in Connections)
            {

            }
        }
        #endregion
    }
}
