
using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        // Using Singleton Pattern
        private static BookingDetailRepository instance = null;
        private static readonly object instanceLock = new object();
        private BookingDetailRepository() { }
        public static BookingDetailRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookingDetailRepository();
                    }
                    return instance;
                }
            }
        }
        FuminiHotelManagementContext _context;
        public bool AddBookingDetail(BookingDetail bookingDetail)
        {
            _context = new();
            _context.Add(bookingDetail);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteBookingDetail(BookingDetail bookingDetail)
        {
            _context = new();
            _context.Remove(bookingDetail);
            return _context.SaveChanges() > 0;
        }

        public async Task<IEnumerable<BookingDetail>> GetBookingDetailsByBookingId(int bookingId)
        {
            _context = new();
            return await _context.BookingDetails
                .Where(b => b.BookingReservationId == bookingId)
                .ToListAsync();
        }

        public bool UpdateBookingDetail(BookingDetail bookingDetail)
        {
            _context = new();
            _context.Update(bookingDetail);
            return _context.SaveChanges() > 0;
        }
    }
}
