using Services.Dtos;
using Services;


using System.Windows;
using System.Windows.Controls;


namespace HotelWpfpApp
{
    /// <summary>
    /// Interaction logic for CustomerManagementUI.xaml
    /// </summary>
    public partial class CustomerManagementUI : Page
    {
        private readonly CustomerService _customerService;
        private CustomerDTO _selected;

        public CustomerManagementUI(CustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();
        }
        private async void Page_Loaded (object sender, RoutedEventArgs e)
        {
            await FillDataGridView();
        }
        private async Task FillDataGridView()
        {
            dgvCustomersList.ItemsSource = await _customerService.GetAllCustomers();
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchValue = txtSearch.Text;

            dgvCustomersList.ItemsSource = await _customerService.GetCustomerBySearchValue(searchValue);
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Please select a certain customer to delete!",
                    "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the selected customer?",
                                                  "Confirm Delete",
                                                  MessageBoxButton.YesNo,
                                                  MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (_customerService.DeleteCustomer(_selected))
                    {
                        MessageBox.Show("Successfully Deleted!","Success",
                            MessageBoxButton.OK,
                            MessageBoxImage.None);
                        await FillDataGridView();
                    }
                    else
                        MessageBox.Show("Fail to delete!");
                }
            }
        }

        private void dgvCustomersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvCustomersList.SelectedItems.Count > 0)
            {
                try
                {
                    _selected = (CustomerDTO)dgvCustomersList.SelectedItems[0];
                }
                catch
                {
                    MessageBox.Show("Please select a valid row!",
                    "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                
            }
            else
            {
                _selected = null;
            }
        }
    }
}
