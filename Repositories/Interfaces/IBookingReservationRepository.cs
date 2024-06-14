using Repositories.Entities;

namespace Repositories.Interfaces
{
    public interface IBookingReservationRepository
    {
        bool AddBooking(BookingReservation b);
        Task<IEnumerable<BookingReservation>> GetAllBookings();

        Task<IEnumerable<BookingReservation>> SearchBookings(string searchvalue);
        Task<IEnumerable<BookingReservation>> GetBookingsByCustomerId(int customerId);
        BookingReservation GetBookingById(int id);
        bool UpdateBooking (BookingReservation b);
        bool DeleteBooking (BookingReservation b);
    }
}
