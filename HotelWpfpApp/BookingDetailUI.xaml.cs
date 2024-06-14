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
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            if (bookingReservationDTO != null)
            {
                tbBookingDate.Text = bookingReservationDTO.BookingDate.ToString();
                tbBookingId.Text = bookingReservationDTO.BookingReservationId.ToString();
                tbBookingStatus.Text = bookingReservationDTO.BookingStatus;
                tbCustomerName.Text = bookingReservationDTO.CustomerName;
                tbPhone.Text = bookingReservationDTO.CustomerPhone;
                tbEmail.Text = bookingReservationDTO.CustomerEmail;

                dgBookingDetails.ItemsSource = bookingReservationDTO.BookingDetails;
                txtActualPrice.Text = "AMOUNT: "+bookingReservationDTO.TotalPrice.ToString();
            }
            
        }
    }
}
