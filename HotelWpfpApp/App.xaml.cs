using JewelryWpfApp.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
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

            var serviceCollection = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@"appsettings.json", optional: true, reloadOnChange: true);
            var config = builder.Build();

            serviceCollection.AddApplicationServices(config);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //var navigationWindow = new NavigationWindow();
            //navigationWindow.Content = serviceProvider.GetRequiredService<Login>();
            //navigationWindow.Show();

            var loginWindow = serviceProvider.GetRequiredService<Login>();
            loginWindow.Show();
        }
    }

}
