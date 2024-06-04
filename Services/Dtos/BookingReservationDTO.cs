using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Dtos
{
    public class BookingReservationDTO
    {
        public BookingReservationDTO()
        {

        }

        public int BookingReservationId { get; set; }
        public DateOnly? BookingDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public byte? BookingStatus { get; set; }
        public required List<BookingDetail> BookingDetails { get; set; }
    }
}
