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
        public EnigmaPage()
        {
            InitializeComponent();
            PopulateWalzen();

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
                            WalzenLage1.Items.Add(rotor);
                            break;
                        case 2:
                            WalzenLage2.Items.Add(rotor);
                            break;
                        case 3:
                            WalzenLage3.Items.Add(rotor);
                            break;
                    }
                }
                else
                {
                    WalzenLage1.Items.Add(rotor);
                    WalzenLage2.Items.Add(rotor);
                    WalzenLage3.Items.Add(rotor);
                }
            }
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
            PopulateWalzen(1, Int32.Parse(WalzenLage3.SelectedItem.ToString()));
        }

        private void WalzenLage2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateWalzen(2, Int32.Parse(WalzenLage3.SelectedItem.ToString()));
        }

        private void ProcessShift_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
