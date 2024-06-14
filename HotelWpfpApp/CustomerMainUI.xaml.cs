using Microsoft.Extensions.DependencyInjection;
using System.Windows;


namespace HotelWpfpApp
{
    /// <summary>
    /// Interaction logic for CustomerMainUI.xaml
    /// </summary>
    public partial class CustomerMainUI : Window
    {
        RoomManagementUI _roomManagementUI;
        BookingManagementUI _bookingManagementUI;
        MyProfileUI _profileUI;
        IServiceProvider _serviceProvider;
        public CustomerMainUI(IServiceProvider serviceProvider, RoomManagementUI roomManagementUI, BookingManagementUI bookingManagementUI, MyProfileUI profileUI)
        {
            _bookingManagementUI = bookingManagementUI;
            _roomManagementUI = roomManagementUI;
            _profileUI = profileUI;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }
        private void StartWindow(object sender, EventArgs e)
        {
            frMain.Content = _bookingManagementUI;
        }
        private void btnNavBooking_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = _bookingManagementUI;
        }

        private void btnNavRoom_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = _roomManagementUI;
        }

        private void btnNavProfile_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = _profileUI;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = _serviceProvider.GetRequiredService<Login>();
            loginWindow.Show();
            Close();
            
        }
    }
}
