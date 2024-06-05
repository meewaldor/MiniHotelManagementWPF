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
            InitializeComponent();
            _customerService = customerService;
            LoadCustomerData();
        }



        private async Task LoadCustomerData()
        {
            IEnumerable<CustomerDTO> customers = await _customerService.GetAllCustomers();
            dgvCustomersList.ItemsSource = customers;
        }
    }
}
