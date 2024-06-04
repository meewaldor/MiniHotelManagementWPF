using System.Windows;
using System.Windows.Controls;

namespace HotelWpfpApp
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        private readonly RoomManagementUI _roomManagementUI;
        private readonly BookingManagementUI _bookingManagementUI;
        private readonly CustomerManagementUI _customerManagementUI;
        public Admin(RoomManagementUI roomManagementUI,CustomerManagementUI customerManagementUI, BookingManagementUI bookingManagementUI )
        {
            _roomManagementUI = roomManagementUI;
            _bookingManagementUI = bookingManagementUI;
            _customerManagementUI = customerManagementUI;
            InitializeComponent();
        }

        private void ManageCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(_customerManagementUI);
        }

        private void ManageBookingButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(_bookingManagementUI);
        }

        private void ManageRoomButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(_roomManagementUI);
        }
    }
}
