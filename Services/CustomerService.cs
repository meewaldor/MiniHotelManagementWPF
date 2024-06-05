
using AutoMapper;
using Repositories;
using Repositories.Dtos;
using Repositories.Entities;
using Repositories.Interfaces;
using Services.Dtos;
using Services.Helpers;

namespace Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        // Check login
        public Customer? CheckLogin(string username, string password)
        {
            return _customerRepository.GetUserAccount(username, password);
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomersConfig();

            var data = _mapper.Map<IEnumerable<Customer>,IEnumerable<CustomerDTO>>(customers);

            return data;
        }
    }
}
