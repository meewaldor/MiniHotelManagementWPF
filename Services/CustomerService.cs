
using Repositories;
using Repositories.Dtos;
using Repositories.Entities;
using Repositories.Interfaces;
using Services.Dtos;

namespace Services
{
    public class CustomerService
    {

        public CustomerService()
        {
        }

        // Check login
        public Customer? CheckLogin(string username, string password)
        {
            return CustomerRepository.Instance.GetUserAccount(username, password);
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            var customers = await CustomerRepository.Instance.GetAllCustomersConfig();

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
