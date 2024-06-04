
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
        private CustomerService customerService;
        private CustomerRepository customerRepository;

        public Login()
        {
            InitializeComponent();
            customerService = new CustomerService();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            Repositories.Entities.Customer customer = customerService.CheckLogin(username, password);

            if (customer != null)
            {
                if (customer.CustomerStatus == 2)
                {
                    // Chuyển đến trang Admin khi người dùng là admin
                    NavigationService?.Navigate(new Admin());
                }
                else
                {
                    // Chuyển đến trang Customer khi người dùng không phải là admin
                    NavigationService?.Navigate(new Customer());
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
