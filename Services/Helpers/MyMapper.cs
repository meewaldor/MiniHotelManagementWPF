using AutoMapper;

using Repositories.Dtos;
using Repositories.Entities;
using Services.Dtos;

namespace Services.Helpers
{
    public class MyMapper : Profile
    {
        public MyMapper() 
        {
            CreateMap<Customer, CustomerDTO>();

            CreateMap<BookingReservation, BookingReservationDTO>()
                .ForMember(d => d.CustomerPhone, o => o.MapFrom(s => s.Customer.Telephone))
                .ForMember(d => d.CustomerName, o => o.MapFrom(s => s.Customer.CustomerFullName))
                .ForMember(d => d.BookingStatus, o => o.MapFrom(s => s.BookingStatus == 1 ? "Pending" : (s.BookingStatus == 2 ? "Confirm" : (s.BookingStatus == 3 ? "Complete" : "Cancel"))));

            CreateMap<BookingDetail, BookingDetailDTO>()
                .ForMember(d => d.RoomNumber, o => o.MapFrom(s => s.Room.RoomNumber))
                .ForMember(d => d.RoomType, o => o.MapFrom(s => s.Room.RoomType.RoomTypeName))
                .ForMember(d => d.MaxCapacity, o => o.MapFrom(s => s.Room.RoomMaxCapacity))
                .ForMember(d => d.PricePerDay, o => o.MapFrom(s => s.Room.RoomPricePerDay));

            CreateMap<RoomInformation, RoomInformationDTO>()
                .ForMember(d => d.RoomTypeName, o => o.MapFrom(s => s.RoomType.RoomTypeName));

        }
    }
}
