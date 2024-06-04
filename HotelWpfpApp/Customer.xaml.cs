using Services;
using System.Windows;
using System.Windows.Controls;

namespace HotelWpfpApp
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Page
    {
        private CustomerService _customerService;

        public Customer(CustomerService customerService)
        {
            InitializeComponent();
            _customerService = customerService;
            LoadCustomerData();
        }

        private async void LoadCustomerData()
        {
            //IEnumerable<CustomerDTO> customers = await customerService.GetAllCustomers();
            //CustomerDataGrid.ItemsSource = customers;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Chuyển đến trang Admin khi nhấn nút Login
            //NavigationService?.Navigate(new Room());
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Chuyển đến trang Admin khi nhấn nút Login
            //NavigationService?.Navigate(new Room());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Chuyển đến trang Admin khi nhấn nút Login
            //NavigationService?.Navigate(new Room());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Chuyển đến trang Admin khi nhấn nút Login
            //NavigationService?.Navigate(new Admin());
        }
    }
}
