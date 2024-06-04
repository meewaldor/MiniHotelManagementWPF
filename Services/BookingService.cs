using Repositories;
using Repositories.Dtos;
using Repositories.Entities;
using Repositories.Interfaces;
using Services.Dtos;

namespace Services
{
    public class BookingService
    {
        public async Task<IEnumerable<BookingReservationDTO>> GetAllBookingReservations()
        {
            var bookingReservations = await BookingReservationRepository.Instance.GetAllBookings();

            var bookingReservationDTOs = bookingReservations
                .Select(b => new BookingReservationDTO
                {
                    BookingReservationId = b.BookingReservationId,
                    BookingDate = b.BookingDate,
                    TotalPrice = b.TotalPrice,
                    CustomerId = b.CustomerId,
                    CustomerName = b.Customer?.CustomerFullName, // Get the customer's full name
                    BookingStatus = b.BookingStatus,
                    BookingDetails = b.BookingDetails.ToList()
                })
                .ToList();

            return bookingReservationDTOs;
        }
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
