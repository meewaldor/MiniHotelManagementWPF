

using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        // Using Singleton Pattern
        private static CustomerRepository instance = null;
        private static readonly object instanceLock = new object();
        private CustomerRepository() { }
        public static CustomerRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerRepository();
                    }
                    return instance;
                }
            }
        }
        FuminiHotelManagementContext _context;

        // Get account by email and password
        public Customer? GetUserAccount(string email, string password)
        {
            _context = new();
            return _context.Customers.FirstOrDefault(
                account => account.EmailAddress.Equals(email) && account.Password.Equals(password)
                );
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersConfig()
        {
            _context = new();
            return await _context.Customers
            .ToListAsync();
        }
    }
}
