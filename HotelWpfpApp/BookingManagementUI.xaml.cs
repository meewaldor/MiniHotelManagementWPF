using Repositories.Dtos;
using Services;
using System.Windows;
using System.Windows.Controls;


namespace HotelWpfpApp
{
    /// <summary>
    /// Interaction logic for BookingManagementUI.xaml
    /// </summary>
    public partial class BookingManagementUI : Page
    {
        private BookingReservationDTO _selected = null;
        private readonly BookingReservationService _bookingReservationService;
        private readonly CustomerService _customerService;
        public BookingManagementUI(BookingReservationService bookingReservationService, CustomerService customerService)
        {
            _bookingReservationService = bookingReservationService;
            _customerService = customerService;
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await FillDataGridView();
        }
        private async Task FillDataGridView()
        {
            var user = _customerService.Customer;

            if (user != null && user.CustomerStatus == 2)
                dgvBookingsList.ItemsSource = await _bookingReservationService.GetAllBookingReservations();
            else if (user != null && user.CustomerStatus == 1)
                dgvBookingsList.ItemsSource = await _bookingReservationService.GetBookingReservationsByCustomerId(user.CustomerId);
        }

        private async void dgvBookingsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvBookingsList.SelectedItems.Count > 0)
            {
                try
                {
                    _selected = (BookingReservationDTO)dgvBookingsList.SelectedItems[0];
                    BookingDetailUI bookingDetailUI = new BookingDetailUI(_bookingReservationService);
                    bookingDetailUI.bookingReservationDTO = _selected;
                    bookingDetailUI.ShowDialog();

                    await FillDataGridView();
                }
                catch
                {
                    MessageBox.Show("Please select a valid row!",
                    "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                
            }
            else
            {
                _selected = null;
            }
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchValue = txtSearch.Text;
            dgvBookingsList.ItemsSource = await _bookingReservationService.SearchBookings(searchValue);
        }

    }
}
