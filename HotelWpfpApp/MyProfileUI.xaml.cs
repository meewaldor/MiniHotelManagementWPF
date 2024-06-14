using Microsoft.IdentityModel.Tokens;
using Repositories.Entities;
using Services;
using Services.Dtos;
using System.Windows;
using System.Windows.Controls;


namespace HotelWpfpApp
{
    /// <summary>
    /// Interaction logic for MyProfileUI.xaml
    /// </summary>
    public partial class MyProfileUI : Page
    {
        private readonly CustomerService _customerService;
        public Customer _customer;
        public MyProfileUI(CustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();
        }

        private void PageLoaded (object sender, RoutedEventArgs e)
        {
           _customer = _customerService.Customer;
            //txtDob.Text = _customer.CustomerBirthday.ToString();
            DataContext = _customer;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var fullName = txtFullname.Text;
            var phone = txtPhone.Text;  
            var email = txtEmail.Text;
            var dob = txtDob.Text;

            if (!fullName.IsNullOrEmpty() && !phone.IsNullOrEmpty() && !email.IsNullOrEmpty() && !dob.IsNullOrEmpty()) 
            {            
                _customer.CustomerFullName = fullName;
                _customer.Telephone = phone;
                _customer.EmailAddress = email;
                _customer.CustomerBirthday = DateOnly.Parse(dob);
                if (_customerService.UpdateCustomer(_customer))
                {
                    MessageBox.Show("Successfully Updated!");
                }
                else
                    MessageBox.Show("Fail to update information!");
            }
            else
            {
                MessageBox.Show("Please fill all information!");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtFullname.Text = _customer.CustomerFullName;
            txtPhone.Text = _customer.Telephone;
            txtEmail.Text = _customer.EmailAddress;
            txtDob.Text = _customer.CustomerBirthday.ToString();
        }
    }
}
