
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Entities;
using Services;
using System.Windows;
using System.Windows.Controls;


namespace HotelWpfpApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly CustomerService _customerService;
        private readonly IServiceProvider _serviceProvider;

        public Login(CustomerService customerService, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _customerService = customerService;
            InitializeComponent();
            
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            Customer customer = _customerService.CheckLogin(username, password);

            if (customer != null)
            {
                _customerService.Customer = customer;
                if (customer.CustomerStatus == 2)
                {
                    // role admin
                    var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    // role customer
                    var mainWindow = _serviceProvider.GetRequiredService<CustomerMainUI>();
                    mainWindow.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
