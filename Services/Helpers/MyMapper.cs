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

            CreateMap<BookingReservation, BookingReservationDTO>();

            CreateMap<BookingDetail, BookingDetailDTO>();

        }
    }
}
