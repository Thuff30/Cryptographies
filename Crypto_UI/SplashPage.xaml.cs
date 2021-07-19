using System.Windows;
using System.Windows.Controls;


namespace Crypto_UI
{ 
    public partial class SplashPage : Page
    {
        public SplashPage()
        {
            InitializeComponent();
        }

        private void ViewMainPageButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).ResetComponents();

        }
    }
}
