

using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {      
        FuminiHotelManagementContext _context;

        public CustomerRepository (FuminiHotelManagementContext context)
        {
            _context = context;
        }

        // Get account by email and password
        public Customer? GetUserAccount(string email, string password)
        {
            return _context.Customers.FirstOrDefault(
                account => account.EmailAddress.Equals(email) && account.Password.Equals(password)
                );
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersConfig()
        {
            return await _context.Customers
            .ToListAsync();
        }
    }
}
