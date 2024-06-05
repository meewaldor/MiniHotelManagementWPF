
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
        private readonly CustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(CustomerRepository customerRepository, IMapper mapper)
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

            var data = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customers);

            return data;
        }

        public bool AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateCustomer(customer);
        }

        public bool DeleteCustomer(Customer customer) 
        {
            return _customerRepository.DeleteCustomer(customer);
        }

        public async Task<CustomerDTO> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);

            var data = _mapper.Map<Customer, CustomerDTO>(customer);

            return data;
        }
    }
}
