using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class RoomInformationDTO
    {
        public int RoomId { get; set; }

        public string RoomNumber { get; set; } = null!;

        public string? RoomDetailDescription { get; set; }

        public int? RoomMaxCapacity { get; set; }

        public int RoomTypeId { get; set; }

        public string? RoomTypeName { get; set; }

        public byte? RoomStatus { get; set; }

        public decimal? RoomPricePerDay { get; set; }

    }
}
