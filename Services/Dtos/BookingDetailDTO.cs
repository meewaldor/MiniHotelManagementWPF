
namespace Services.Dtos
{
    public class BookingDetailDTO
    {
        public string RoomType { get; set; }
        public string RoomNumber { get; set; }
        public int MaxCapacity { get; set; }
        public decimal PricePerDay { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal ActualPrice { get; set; }
    }
}
