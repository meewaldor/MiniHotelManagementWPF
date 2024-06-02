using Repositories;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Services
{
    public class BookingService
    {
        public bool AddBooking (BookingReservation bookingReservation)
        {
            return BookingReservationRepository.Instance.AddBooking (bookingReservation);
        }

        public bool UpdateBooking (BookingReservation bookingReservation)
        {
            return BookingReservationRepository.Instance.UpdateBooking (bookingReservation);
        }
        public bool DeleteBooking (BookingReservation bookingReservation)
        {
            return BookingReservationRepository.Instance.DeleteBooking(bookingReservation);
        }

        public async Task<IEnumerable<BookingReservation>> GetAllBooingReservations ()
        {
            return await BookingReservationRepository.Instance.GetAllBookings();
        }

        public async Task<IEnumerable<BookingReservation>> GetBookingReservationsByCustomerId (int customerId)
        {
            return await BookingReservationRepository.Instance.GetBookingsByCustomerId (customerId);
        }
        public BookingReservation GetBookingReservationById (int id)
        {
            return BookingReservationRepository.Instance.GetBookingById (id);
        }
    }
}
