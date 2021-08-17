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
        public void PopulateWalzen() 
        {
            foreach(var rotor in Walzen)
            {
                WalzenLage1.Items.Add(rotor);
                WalzenLage2.Items.Add(rotor);
                WalzenLage3.Items.Add(rotor);
            }
        }
        public void PopulateWalzen(int nonRotor, int selected)
        {
            foreach (var rotor in Walzen)
            {
                if (rotor == selected)
                {
                    switch (nonRotor)
                    {
                        case 1:
                            if (WalzenLage2.Items.Contains(rotor))
                            {
                                WalzenLage2.Items.Remove(rotor);
                            }
                            if (WalzenLage3.Items.Contains(rotor))
                            {
                                WalzenLage3.Items.Remove(rotor);
                            }
                            break;
                        case 2:
                            if (WalzenLage1.Items.Contains(rotor))
                            {
                                WalzenLage1.Items.Remove(rotor);
                            }
                            if (WalzenLage3.Items.Contains(rotor))
                            {
                                WalzenLage3.Items.Remove(rotor);
                            }
                            break;
                        case 3:
                            if (WalzenLage1.Items.Contains(rotor))
                            {
                                WalzenLage1.Items.Remove(rotor);
                            }
                            if (WalzenLage2.Items.Contains(rotor))
                            {
                                WalzenLage2.Items.Remove(rotor);
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if (!WalzenLage1.Items.Contains(rotor) && checkWalzen(WalzenLage2, rotor) && checkWalzen(WalzenLage3,rotor))
                    {
                        WalzenLage1.Items.Insert(rotor - 1, rotor);
                    }
                    if (!WalzenLage2.Items.Contains(rotor) && checkWalzen(WalzenLage1, rotor) && checkWalzen(WalzenLage3, rotor))
                    {
                        WalzenLage2.Items.Insert(rotor - 1, rotor);
                    }
                    if (!WalzenLage3.Items.Contains(rotor) && checkWalzen(WalzenLage1, rotor) && checkWalzen(WalzenLage2, rotor))
                    {
                        WalzenLage3.Items.Insert(rotor - 1, rotor);
                    }
                }
            }
        }
        private bool checkWalzen(ComboBox walzen, int check)
        {
            if(walzen.SelectedItem != null)
            {
                if(Int32.Parse(walzen.SelectedItem.ToString()) != check){
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public void PopulateSteckerbrett()
        {
            List<ComboBox> stecker = new List<ComboBox> { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z };
            foreach (var letter in reference)
            {
                foreach (var box in stecker)
                {
                    if (box.Name != letter.ToString())
                    {
                        box.Items.Add(letter);
                    }
                }
            }
        }
        public void PopulateSteckerbrett(char selectedBox, char selected)
        {
            List<ComboBox> stecker = new List<ComboBox> { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z };

            foreach (var box in stecker)
            {
                if(box.Name != selectedBox.ToString() && box.Items.Contains(selected))
                {
                        box.Items.Remove(selected);
                }
                if(box.Name == selected.ToString())
                {
                    box.SelectedIndex = box.Items.IndexOf(selectedBox);
                }
                else if(box.Items.Contains(selectedBox))
                {
                    box.Items.Remove(selectedBox);
                }
            }
            foreach(var letter in reference)
            {
                if (CheckStecker(stecker, letter))
                {
                    foreach (var box in stecker)
                    {
                        if (!box.Items.Contains(letter))
                        {
                            if (Array.IndexOf(reference, letter) - 1 < 0)
                            {
                                box.Items.Insert(0, letter);

                            }
                            else 
                            { 
                                var prelet = reference[Array.IndexOf(reference, letter) - 1];
                                box.Items.Insert(box.Items.IndexOf(reference[Array.IndexOf(reference, letter) - 1]) + 1, letter);
                            }
                        }
                    }
                }
            }
        }
        private bool CheckStecker(List<ComboBox> stecker, char letter)
        {
            foreach(var box in stecker)
            {
                if(box.SelectedItem != null && Char.Parse(box.SelectedItem.ToString()) == letter)
                {
                    return false;
                }
            }
            return true;
        }

        private void Grundstellung1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void WalzenLage3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateWalzen(3, Int32.Parse(WalzenLage3.SelectedItem.ToString()));
        }

        private void WalzenLage1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateWalzen(1, Int32.Parse(WalzenLage1.SelectedItem.ToString()));
        }

        private void WalzenLage2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateWalzen(2, Int32.Parse(WalzenLage2.SelectedItem.ToString()));
        }

        private void ProcessShift_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Q_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Q.SelectedItem != null)
            {
                PopulateSteckerbrett('Q', Char.Parse(Q.SelectedItem.ToString()));
            }
        }

        private void W_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (W.SelectedItem != null)
            {
                PopulateSteckerbrett('W', Char.Parse(W.SelectedItem.ToString()));
            }
        }

        private void E_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (E.SelectedItem != null)
            {
                PopulateSteckerbrett('E', Char.Parse(E.SelectedItem.ToString()));
            }
        }

        private void R_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (R.SelectedItem != null)
            {
                PopulateSteckerbrett('R', Char.Parse(R.SelectedItem.ToString()));
            }
        }

        private void T_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (T.SelectedItem != null)
            {
                PopulateSteckerbrett('T', Char.Parse(T.SelectedItem.ToString()));
            }
        }

        private void Z_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('Z', Char.Parse(Z.SelectedItem.ToString()));

        }

        private void U_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('U', Char.Parse(U.SelectedItem.ToString()));

        }

        private void I_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('I', Char.Parse(I.SelectedItem.ToString()));

        }

        private void O_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('O', Char.Parse(O.SelectedItem.ToString()));

        }

        private void A_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('A', Char.Parse(A.SelectedItem.ToString()));

        }

        private void S_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('S', Char.Parse(S.SelectedItem.ToString()));

        }

        private void D_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('D', Char.Parse(D.SelectedItem.ToString()));

        }

        private void F_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('F', Char.Parse(F.SelectedItem.ToString()));

        }

        private void G_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('G', Char.Parse(G.SelectedItem.ToString()));

        }

        private void H_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('H', Char.Parse(H.SelectedItem.ToString()));

        }

        private void J_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('J', Char.Parse(J.SelectedItem.ToString()));

        }

        private void K_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('K', Char.Parse(K.SelectedItem.ToString()));

        }

        private void P_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('P', Char.Parse(P.SelectedItem.ToString()));

        }

        private void Y_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('Y', Char.Parse(Y.SelectedItem.ToString()));

        }

        private void X_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('X', Char.Parse(X.SelectedItem.ToString()));

        }

        private void C_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('C', Char.Parse(C.SelectedItem.ToString()));

        }

        private void V_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('V', Char.Parse(V.SelectedItem.ToString()));

        }

        private void B_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('B', Char.Parse(B.SelectedItem.ToString()));

        }

        private void N_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('N', Char.Parse(N.SelectedItem.ToString()));

        }

        private void M_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('M', Char.Parse(M.SelectedItem.ToString()));

        }

        private void L_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSteckerbrett('L', Char.Parse(L.SelectedItem.ToString()));

        }
    }
}
