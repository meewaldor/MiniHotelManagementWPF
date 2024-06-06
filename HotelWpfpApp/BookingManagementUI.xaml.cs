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
        private readonly BookingDetailUI _bookingDetailUI;
        public BookingManagementUI(BookingReservationService bookingReservationService, BookingDetailUI bookingDetailUI)
        {
            _bookingReservationService = bookingReservationService;
            InitializeComponent();
            _bookingDetailUI = bookingDetailUI;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await FillDataGridView();
        }
        private async Task FillDataGridView()
        {
            dgvBookingsList.ItemsSource = await _bookingReservationService.GetAllBookingReservations();
        }

        private async void dgvBookingsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvBookingsList.SelectedItems.Count > 0)
            {
                _selected = (BookingReservationDTO) dgvBookingsList.SelectedItems[0];
                //BookingDetailUI bookingDetailUI = new BookingDetailUI(_bookingReservationService);
                _bookingDetailUI.bookingReservationDTO = _selected;
                _bookingDetailUI.ShowDialog();

                await FillDataGridView();
            }
            else
            {
                _selected = null;
            }
        }
    }
}
