
using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class BookingReservationRepository : IBookingReservationRepositoty
    {
        FuminiHotelManagementContext _context;

        public BookingReservationRepository(FuminiHotelManagementContext context)
        {
            _context = context;            
        }

        public bool AddBooking(BookingReservation b)
        {
            _context = new();
            _context.Add(b);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteBooking(BookingReservation b)
        {
            _context = new();
            _context.Remove(b);
            return _context.SaveChanges() > 0;
        }

        public async Task<IEnumerable<BookingReservation>> GetAllBookings()
        {
            _context = new();
            return await _context.BookingReservations
            .Include(b => b.Customer) 
            .Include(b => b.BookingDetails) 
            .ToListAsync();
        }

        public BookingReservation GetBookingById(int id)
        {
            _context = new();
            return _context.BookingReservations.Find(id);
        }

        public async Task<IEnumerable<BookingReservation>> GetBookingsByCustomerId(int customerId)
        {
            _context = new();
            return await _context.BookingReservations
                .Where(b => b.CustomerId == customerId)
                .ToListAsync();
        }

        public bool UpdateBooking(BookingReservation b)
        {
            _context = new();
            _context.Update(b);
            return _context.SaveChanges() > 0;
        }
    }
}
