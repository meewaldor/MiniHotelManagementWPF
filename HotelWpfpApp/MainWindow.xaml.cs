using Microsoft.Extensions.DependencyInjection;
using Services;
using System.Windows;
using System.Windows.Controls;


namespace HotelWpfpApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RoomManagementUI _roomManagementUI;
        BookingManagementUI _bookingManagementUI;
        CustomerManagementUI _customerManagementUI;
        IServiceProvider _serviceProvider;
        public MainWindow(IServiceProvider serviceProvider, RoomManagementUI roomManagementUI, BookingManagementUI bookingManagementUI, CustomerManagementUI customerManagementUI, BookingDetailUI bookingDetailUI)
        {
            _bookingManagementUI = bookingManagementUI;            
            _customerManagementUI = customerManagementUI;
            _roomManagementUI = roomManagementUI;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            
        }
        private void StartWindow(object sender, EventArgs e)
        {
            frMain.Content = _roomManagementUI;
        }
        private void btnNavBooking_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = _bookingManagementUI;
        }

        private void btnNavCustomer_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = _customerManagementUI;
        }

        private void btnNavRoom_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = _roomManagementUI;
        }

        private void btnNavProfile_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            var loginWindow = _serviceProvider.GetRequiredService<Login>();
            loginWindow.Show();
        }
    }
}