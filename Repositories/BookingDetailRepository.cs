using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        FuminiHotelManagementContext _context;

        public BookingDetailRepository(FuminiHotelManagementContext context)
        {
            _context = context;
        }
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
