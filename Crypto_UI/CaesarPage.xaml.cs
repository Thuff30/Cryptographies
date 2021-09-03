using System;
using System.Windows;
using System.Windows.Controls;
using Cryptographies;

namespace Crypto_UI
{
    public partial class CaesarPage : Page
    {
        public CaesarPage()
        {
            InitializeComponent();
            Loaded += HideElements;
        }

        private void ProcessShift_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(UserInput.Text) && !String.IsNullOrWhiteSpace(Shift.Text))
            {
                if ((bool)EncodeRadio.IsChecked)
                {
                    Error.Text = "";
                    Output.Text = CaeserShift.Encode(UserInput.Text, Int32.Parse(Shift.Text));
                }
                else if ((bool)DecodeRadio.IsChecked)
                {
                    Error.Text = "";
                    Output.Text = CaeserShift.Decode(UserInput.Text, Int32.Parse(Shift.Text));
                }
                else
                {
                    Error.Text = "Please select Encode or Decode to process your message.";
                }
            }
            else
            {
                Error.Text = "Please enter a message to encode and the number of lettters the cipher will shift.";
            }
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            UserInput.Text = "Message";
            Output.Text = "Result";
            Error.Text = "";
        }

        private void EncodeRadio_Click(object sender, RoutedEventArgs e)
        {
            
            EncodeText.Text = "Enter a message to encode";
            ShowElements();
        }

        private void DecodeRadio_Click(object sender, RoutedEventArgs e)
        {
            EncodeText.Text = "Enter a message to decode";
            ShowElements();
        }

        public void HideElements(object sender, RoutedEventArgs e)
        {
            EncodeText.Visibility = Visibility.Hidden;
            UserInput.Visibility = Visibility.Hidden;
            ShiftText.Visibility = Visibility.Hidden;
            Shift.Visibility = Visibility.Hidden;
            ProcessShift.Visibility = Visibility.Hidden;
            ClearForm.Visibility = Visibility.Hidden;
            ResultText.Visibility = Visibility.Hidden;
            Output.Visibility = Visibility.Hidden;
        }
        public void ShowElements()
        {
            EncodeText.Visibility = Visibility.Visible;
            UserInput.Visibility = Visibility.Visible;
            ShiftText.Visibility = Visibility.Visible;
            Shift.Visibility = Visibility.Visible;
            ProcessShift.Visibility = Visibility.Visible;
            ClearForm.Visibility = Visibility.Visible;
            ResultText.Visibility = Visibility.Visible;
            Output.Visibility = Visibility.Visible;
        }
    }
}
