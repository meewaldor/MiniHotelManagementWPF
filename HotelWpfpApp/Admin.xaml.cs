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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        private readonly RoomInformationService _roomInformationService;
        public Admin(RoomInformationService roomInformationService)
        {
            _roomInformationService = roomInformationService;
            InitializeComponent();
        }

        private void ManageCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Customer());
        }

        private void ManageBookingButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Booking());
        }

        private void ManageRoomButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RoomManagementUI(_roomInformationService));
        }
    }
}
