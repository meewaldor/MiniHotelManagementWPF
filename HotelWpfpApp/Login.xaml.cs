
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
        private readonly MainWindow _mainWindow;
        //private readonly RoomManagementUI _roomManagementUI;

        public Login(CustomerService customerService, MainWindow mainWindow)
        {
            _customerService = customerService;
            _mainWindow = mainWindow;
            //_roomManagementUI = roomManagementUI;
            InitializeComponent();            
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            Customer customer = _customerService.CheckLogin(username, password);

            if (customer != null)
            {
                if (customer.CustomerStatus == 2)
                {
                    // role admin
                    //NavigationService?.Navigate(_mainWindow);
                    _mainWindow.Show();
                    this.Close();
                    //frLogin.Content = _roomManagementUI;
                }
                else
                {
                    // role customer
                    //NavigationService?.Navigate(_customer);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
