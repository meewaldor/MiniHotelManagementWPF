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
            CreateMap<Customer, CustomerDTO>()
                .ForMember(d => d.CustomerId, o => o.MapFrom(s => s.CustomerId))
                .ForMember(d => d.CustomerFullName, o => o.MapFrom(s => s.CustomerFullName))
                .ForMember(d => d.Telephone, o => o.MapFrom(s => s.Telephone))
                .ForMember(d => d.EmailAddress, o => o.MapFrom(s => s.EmailAddress))
                .ForMember(d => d.CustomerBirthday, o => o.MapFrom(s => s.CustomerBirthday));

            CreateMap<BookingReservation, BookingReservationDTO>()
                .ForMember(d => d.BookingReservationId, o => o.MapFrom(s => s.BookingReservationId))
                .ForMember(d => d.BookingDate, o => o.MapFrom(s => s.BookingDate))
                .ForMember(d => d.TotalPrice, o => o.MapFrom(s => s.TotalPrice))
                .ForMember(d => d.CustomerName, o => o.MapFrom(s => s.Customer.CustomerFullName))
                .ForMember(d => d.BookingStatus, o => o.MapFrom(s => s.BookingStatus))
                .ForMember(d => d.BookingDetails, o => o.MapFrom(s => s.BookingDetails));

            CreateMap<BookingDetail, BookingDetailDTO>();
                //.ForMember(d => d.RoomId, o => o.MapFrom(s => s.RoomId))
                //.ForMember(d => d.StartDate, o => o.MapFrom(s => s.StartDate))
                //.ForMember(d => d.EndDate, o => o.MapFrom(s => s.EndDate))
                //.ForMember(d => d.Price, o => o.MapFrom(s => s.)
                //.ForMember(d => d.BookingStatus, o => o.MapFrom(s => s.BookingStatus))
                //.ForMember(d => d.BookingDetails, o => o.MapFrom(s => s.BookingDetails));

        }
    }
}
