using Repositories.Entities;

namespace Repositories.Interfaces
{
    public interface IBookingDetailRepository
    {
        Task<IEnumerable<BookingDetail>> GetBookingDetailsByBookingId(int bookingId);
        bool AddBookingDetail (BookingDetail bookingDetail);
        bool UpdateBookingDetail(BookingDetail bookingDetail);
        bool DeleteBookingDetail(BookingDetail bookingDetail);
    }
}
