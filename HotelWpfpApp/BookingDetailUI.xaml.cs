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
                tbCustomerName.Text = bookingReservationDTO.CustomerName;
                tbPhone.Text = bookingReservationDTO.CustomerPhone;

                dgBookingDetails.ItemsSource = bookingReservationDTO.BookingDetails;
                //txtTotalPrice.Text = bookingReservationDTO.TotalPrice.ToString();
            }
            
        }
    }
}
