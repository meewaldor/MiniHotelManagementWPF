using AutoMapper;
using Repositories.Entities;
using Services.Dtos;

namespace Services.Helpers
{
    public class MyMapper : Profile
    {
        public MyMapper() 
        {
            CreateMap<Customer, CustomerDTO>();    
        }
    }
}
