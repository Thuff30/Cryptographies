using System.Windows;

namespace Crypto_UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainInst.Visibility = Visibility.Hidden;
            CaesarRadio.Visibility = Visibility.Hidden;
            VigenereRadio.Visibility = Visibility.Hidden;
            EnigmaRadio.Visibility = Visibility.Hidden;
            Loaded += Display_Splash;
        }
        public void Display_Splash(object sender, RoutedEventArgs e)
        {
            StartingFrame.NavigationService.Navigate(new SplashPage());
        }
        public void ResetComponents()
        {
            MainInst.Visibility = Visibility.Visible;
            CaesarRadio.Visibility = Visibility.Visible;
            VigenereRadio.Visibility = Visibility.Visible;
            EnigmaRadio.Visibility = Visibility.Visible;
            StartingFrame.Content = null;
        }

        private void CaesarRadio_Checked(object sender, RoutedEventArgs e)
        {
            FormFrame.NavigationService.Navigate(new CaesarPage());
        }

        private void VigenereRadio_Checked(object sender, RoutedEventArgs e)
        {
            FormFrame.NavigationService.Navigate(new VigeneresPage());
        }

        private void EnigmaRadio_Checked(object sender, RoutedEventArgs e)
        {
            FormFrame.NavigationService.Navigate(new EnigmaPage());
        }
    }
}
