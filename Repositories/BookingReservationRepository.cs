
using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class BookingReservationRepository : IBookingReservationRepository
    {
        FuminiHotelManagementContext _context;

        public BookingReservationRepository(FuminiHotelManagementContext context)
        {
            _context = context;            
        }

        public bool AddBooking(BookingReservation b)
        {
            _context.Add(b);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteBooking(BookingReservation b)
        {
            _context.Remove(b);
            return _context.SaveChanges() > 0;
        }

        public async Task<IEnumerable<BookingReservation>> GetAllBookings()
        {
            return await _context.BookingReservations
            .Include(b => b.Customer) 
            .Include(b => b.BookingDetails) 
            .ThenInclude(b => b.Room)
            .ThenInclude( b => b.RoomType)
            .ToListAsync();
        }

        public async Task<IEnumerable<BookingReservation>> SearchBookings(string searchvalue)
        {
            return await _context.BookingReservations
            .Where(b => b.BookingReservationId.ToString() == searchvalue 
            || b.Customer.CustomerFullName.Contains(searchvalue) 
            || b.Customer.Telephone.Contains(searchvalue))
            .Include(b => b.Customer)
            .Include(b => b.BookingDetails)
            .ThenInclude(b => b.Room)
            .ThenInclude(b => b.RoomType)
            .ToListAsync();
        }

        public BookingReservation GetBookingById(int id)
        {
            return _context.BookingReservations.Find(id);
        }

        public async Task<IEnumerable<BookingReservation>> GetBookingsByCustomerId(int customerId)
        {
            return await _context.BookingReservations
                .Where(b => b.CustomerId == customerId)
                .Include(b => b.Customer)
                .Include(b => b.BookingDetails)
                .ThenInclude(b => b.Room)
                .ThenInclude(b => b.RoomType)
                .ToListAsync();
        }

        public bool UpdateBooking(BookingReservation b)
        {
            _context.Update(b);
            return _context.SaveChanges() > 0;
        }
    }
}
