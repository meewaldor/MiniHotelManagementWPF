
using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class BookingReservationRepository : IBookingReservationRepositoty
    {
        // Using Singleton Pattern
        private static BookingReservationRepository instance = null;
        private static readonly object instanceLock = new object();
        private BookingReservationRepository() { }
        public static BookingReservationRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookingReservationRepository();
                    }
                    return instance;
                }
            }
        }
        FuminiHotelManagementContext _context;
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
