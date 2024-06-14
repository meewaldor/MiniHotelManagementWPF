

using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {      
        private readonly FuminiHotelManagementContext _context;

        public CustomerRepository (FuminiHotelManagementContext context)
        {
            _context = context;
        }

        // Get account by email and password
        public Customer? GetUserAccount(string email, string password)
        {
            return _context.Customers
                .FirstOrDefault(
                account => account.EmailAddress.Equals(email) 
                && account.Password.Equals(password)
                && account.CustomerStatus != 0
                );
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersConfig()
        {
            return await _context.Customers
            //.AsNoTracking()
            .Where(c => c.CustomerStatus == 1)
            .ToListAsync();
        }

        public bool AddCustomer(Customer customer)
        {
            _context.Add(customer);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateCustomer(Customer customer)
        {
            _context.Attach(customer);
            _context.Entry(customer).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        //public async Task<IEnumerable<Customer>> GetCustomersByBookingId(int bookingReservationId)
        //{
        //    _context = new();
        //    return await _context.BookingReservations.Find(bookingReservationId);
        //}

        public async Task<IEnumerable<Customer>> GetCustomerBySearchValue(string searchValue)
        {
            return await _context.Customers
                .Where(c => c.CustomerStatus == 1 && (c.CustomerId.ToString() == searchValue ||
                c.CustomerFullName.Contains(searchValue)|| 
                c.Telephone.Contains(searchValue) || 
                c.EmailAddress.Contains(searchValue)))
                .ToListAsync();
        }

        public bool DeleteCustomer(Customer customer)
        {
            _context.Attach(customer);
            _context.Entry(customer).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public Customer? GetCustomerById(int customerId)
        {
            return _context.Customers.Find(customerId);
        }
    }
}
