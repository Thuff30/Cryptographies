using System;
using System.Windows;
using System.Windows.Controls;
using Cryptographies;

namespace Crypto_UI
{
    public partial class VigeneresPage : Page
    {
        public VigeneresPage()
        {
            InitializeComponent();
            Loaded += HideElements;
        }
        private void ProcessShift_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)EncodeRadio.IsChecked)
            {
                Output.Text = Vigenere.Encode(UserInput.Text, Key.Text, Int32.Parse(Shift.Text));
            }
            if ((bool)DecodeRadio.IsChecked)
            {
                Output.Text = Vigenere.Decode(UserInput.Text, Key.Text, Int32.Parse(Shift.Text));
            }
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            UserInput.Text = "Message";
            Output.Text = "Result";
            Key.Text = "Key";
        }

        private void EncodeRadio_Click(object sender, RoutedEventArgs e)
        {
            EncodeText.Visibility = Visibility.Visible;
            ShowElements();
        }

        private void DecodeRadio_Click(object sender, RoutedEventArgs e)
        {
            DecodeText.Visibility = Visibility.Visible;
            ShowElements();
        }

        public void HideElements(object sender, RoutedEventArgs e)
        {
            EncodeText.Visibility = Visibility.Hidden;
            DecodeText.Visibility = Visibility.Hidden;
            UserInput.Visibility = Visibility.Hidden;
            ShiftText.Visibility = Visibility.Hidden;
            Shift.Visibility = Visibility.Hidden;
            KeyText.Visibility = Visibility.Hidden;
            Key.Visibility = Visibility.Hidden;
            ProcessShift.Visibility = Visibility.Hidden;
            ClearForm.Visibility = Visibility.Hidden;
            ResultText.Visibility = Visibility.Hidden;
            Output.Visibility = Visibility.Hidden;
        }
        public void ShowElements()
        {
            UserInput.Visibility = Visibility.Visible;
            ShiftText.Visibility = Visibility.Visible;
            Shift.Visibility = Visibility.Visible;
            KeyText.Visibility = Visibility.Visible;
            Key.Visibility = Visibility.Visible;
            ProcessShift.Visibility = Visibility.Visible;
            ClearForm.Visibility = Visibility.Visible;
            ResultText.Visibility = Visibility.Visible;
            Output.Visibility = Visibility.Visible;
        }

    }
}
