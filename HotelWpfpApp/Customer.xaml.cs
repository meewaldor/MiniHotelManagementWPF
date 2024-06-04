﻿using Repositories;
using Repositories.Dtos;
using Services;
using Services.Dtos;
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
            IEnumerable<CustomerDTO> customers = await _customerService.GetAllCustomers();
            CustomerDataGrid.ItemsSource = customers;
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
