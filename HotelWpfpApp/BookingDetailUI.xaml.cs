using Repositories.Dtos;
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
    /// Interaction logic for BookingDetailUI.xaml
    /// </summary>
    public partial class BookingDetailUI : Window
    {
        public BookingReservationDTO bookingReservationDTO;
        private readonly BookingReservationService _bookingReservationService;

        public BookingDetailUI(BookingReservationService bookingReservationService)
        {
            _bookingReservationService = bookingReservationService;
            InitializeComponent();
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await FillData();
        }

        private async Task FillData()
        {
            if (bookingReservationDTO != null)
            {
                tbBookingDate.Text = bookingReservationDTO.BookingDate.ToString();
                tbBookingId.Text = bookingReservationDTO.BookingReservationId.ToString();
                tbBookingStatus.Text = bookingReservationDTO.BookingStatus;
                tbCheckin.Text = bookingReservationDTO.BookingDetails[0].StartDate.ToString();
                tbCheckout.Text = bookingReservationDTO.BookingDetails[0].EndDate.ToString();
                tbCustomerName.Text = bookingReservationDTO.CustomerName;
                tbPhone.Text = bookingReservationDTO.CustomerPhone;
                tbRoomType.Text = bookingReservationDTO.BookingDetails[0].Room.RoomType.RoomTypeName;
                tbRoomNumber.Text = bookingReservationDTO.BookingDetails[0].Room.RoomNumber;
                tbCapacity.Text = bookingReservationDTO.BookingDetails[0].Room.RoomMaxCapacity.ToString();
                tbPricePerDay.Text = bookingReservationDTO.BookingDetails[0].Room.RoomPricePerDay.ToString();
                txtTotalPrice.Text = bookingReservationDTO.TotalPrice.ToString();
            }
            
        }
    }
}
