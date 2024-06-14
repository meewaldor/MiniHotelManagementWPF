
using AutoMapper;
using Repositories;
using Repositories.Dtos;
using Repositories.Entities;
using Repositories.Interfaces;
using Services.Dtos;
using Services.Helpers;
using System.Collections.Generic;

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
        public Customer Customer {  get; set; }
        // Check login
        public Customer CheckLogin(string username, string password)
        {
            return _customerRepository.GetUserAccount(username, password);
        }

        public bool DeleteCustomer(CustomerDTO customerDto)
        {
            var customer = _customerRepository.GetCustomerById(customerDto.CustomerId);
            if (customer == null) { return false; }
            _mapper.Map(customerDto, customer);
            customer.CustomerStatus = 0;
            return _customerRepository.DeleteCustomer(customer);
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomersConfig();

            var data = _mapper.Map<IEnumerable<Customer>,IEnumerable<CustomerDTO>>(customers);

            return data;
        }

        public async Task<IEnumerable<CustomerDTO>> GetCustomerBySearchValue(string searchValue)
        {
            var customers = await _customerRepository.GetCustomerBySearchValue(searchValue);

            var customerData = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customers);

            return customerData;
        }

        public bool UpdateCustomer (Customer customer)
        {
            //Customer = _mapper.Map<Customer>(customerDto);
            return _customerRepository.UpdateCustomer(customer);
        }
    }
}
