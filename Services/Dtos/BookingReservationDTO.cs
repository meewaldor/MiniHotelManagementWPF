using Services.Dtos;

namespace Repositories.Dtos
{
    public class BookingReservationDTO
    {
        public int BookingReservationId { get; set; }
        public DateOnly? BookingDate { get; set; }
        public string CustomerPhone { get; set; }
        public string? CustomerName { get; set; }
        public string BookingStatus { get; set; }
        public decimal? TotalPrice { get; set; }
        public List<BookingDetailDTO> BookingDetails { get; set; }
    }
}
