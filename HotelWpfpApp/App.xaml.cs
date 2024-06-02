using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;

namespace HotelWpfpApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            NavigationWindow navigationWindow = new NavigationWindow();
            navigationWindow.Content = new Login(); // Trang chính của ứng dụng
            navigationWindow.Show();
        }
    }

}
