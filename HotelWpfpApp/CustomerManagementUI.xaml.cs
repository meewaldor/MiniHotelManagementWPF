using Services.Dtos;
using Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Repositories.Entities;

namespace HotelWpfpApp
{
    /// <summary>
    /// Interaction logic for CustomerManagementUI.xaml
    /// </summary>
    public partial class CustomerManagementUI : Page
    {
        CustomerService _customerService;
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
    }
}
