
using Repositories;
using Repositories.Dtos;
using Repositories.Entities;
using Repositories.Interfaces;
using Services.Dtos;

namespace Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // Check login
        public Customer? CheckLogin(string username, string password)
        {
            return _customerRepository.GetUserAccount(username, password);
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomersConfig();

            var customerDTOs = customers
                .Select(b => new CustomerDTO
                {
                    CustomerId = b.CustomerId,
                    CustomerFullName = b.CustomerFullName,
                    Telephone = b.Telephone,
                    EmailAddress = b.EmailAddress,
                    CustomerBirthday = string.Concat(b.CustomerBirthday)
                })
                .ToList();

            return customerDTOs;
        }
    }
}
