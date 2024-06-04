
using Repositories;
using Services;
using System.Windows;
using System.Windows.Controls;


namespace HotelWpfpApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private readonly CustomerService _customerService;
        private readonly Admin _admin;
        private readonly Customer _customer;

        public Login(CustomerService customerService, Admin admin, Customer customer)
        {
            _customerService = customerService;
            _admin = admin;
            _customer = customer;
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            Repositories.Entities.Customer customer = _customerService.CheckLogin(username, password);

            if (customer != null)
            {
                if (customer.CustomerStatus == 2)
                {
                    // role admin
                    NavigationService?.Navigate(_admin);
                }
                else
                {
                    // role customer
                    NavigationService?.Navigate(_customer);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
