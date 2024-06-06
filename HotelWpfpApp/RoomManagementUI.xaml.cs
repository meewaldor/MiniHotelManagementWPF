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
    /// Interaction logic for RoomManagementUI.xaml
    /// </summary>
    public partial class RoomManagementUI : Page
    {
        RoomInformationService _roomInformationService;
        BookingManagementUI _bookingManagementUI;
        CustomerManagementUI _customerManagementUI;
        //public RoomManagementUI(RoomInformationService roomInformationService, BookingManagementUI bookingManagementUI, CustomerManagementUI customerManagementUI)
        //{
        //    _roomInformationService = roomInformationService;
        //    _bookingManagementUI = bookingManagementUI;
        //    _customerManagementUI = customerManagementUI;
        //    InitializeComponent();          
        //}

        public RoomManagementUI(RoomInformationService roomInformationService)
        {
            _roomInformationService = roomInformationService;
            InitializeComponent();
        }


        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await FillDataGridView();
        }

        private async Task FillDataGridView()
        {
            //dgvRoomsList.ItemsSource = null;
            dgvRoomsList.ItemsSource = await _roomInformationService.GetAllRoomInformations();
        }

        private void btnNavBooking_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_bookingManagementUI);
        }

        private void btnNavCustomer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_customerManagementUI);
        }
    }
}
