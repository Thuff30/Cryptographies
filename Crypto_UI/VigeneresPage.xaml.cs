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
            if (VerifyInput())
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
        }

        private bool VerifyInput()
        {
            bool success = false;
            int ranInt;

            //Verify UserInput field
            if(!Int32.TryParse(UserInput.Text, out ranInt))
            {
                if(SharedFunctions.ConvertToArray(UserInput.Text).Length > 0)
                {
                    success = true;
                    MessageErrorText.Visibility = Visibility.Hidden;
                }
                else
                {
                    success = false;
                    MessageErrorText.Visibility = Visibility.Visible;
                }
            }
            else
            {
                success = false;
                MessageErrorText.Visibility = Visibility.Visible;
            }

            //Verify Shift field
            try
            {
                int test = Int32.Parse(Shift.Text);
                if(test >= 0 && test <= 25)
                {
                    success = true;
                    ShiftErrorText.Visibility = Visibility.Hidden;
                }
                else
                {
                    success = false;
                    ShiftErrorText.Visibility = Visibility.Visible;
                }

            }catch(Exception ex)
            {
                ShiftErrorText.Visibility = Visibility.Visible;
                success = false;
            }

            //Verify Key field
            if (!Int32.TryParse(Key.Text, out ranInt))
            {
                if (SharedFunctions.ConvertToArray(Key.Text).Length > 0)
                {
                    success = true;
                    PhraseErrorText.Visibility = Visibility.Hidden;
                }
                else
                {
                    success = false;
                    PhraseErrorText.Visibility = Visibility.Visible;
                }
            }
            else
            {
                success = false;
                PhraseErrorText.Visibility = Visibility.Visible;
            }

            return success;
        }

            private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            UserInput.Text = "Message";
            Output.Text = "Result";
            Key.Text = "Key";
            Shift.Text = "0";
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
            KeyText.Visibility = Visibility.Hidden;
            Key.Visibility = Visibility.Hidden;
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
            KeyText.Visibility = Visibility.Visible;
            Key.Visibility = Visibility.Visible;
            ProcessShift.Visibility = Visibility.Visible;
            ClearForm.Visibility = Visibility.Visible;
            ResultText.Visibility = Visibility.Visible;
            Output.Visibility = Visibility.Visible;
        }

    }
}
