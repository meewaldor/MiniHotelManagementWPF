

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

        public bool AddCustomer(Customer customer)
        {
            _context = new();
            _context.Add(customer);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateCustomer(Customer customer)
        {
            _context = new();
            _context.Update(customer);
            return _context.SaveChanges() > 0;
        }

        //public async Task<IEnumerable<Customer>> GetCustomersByBookingId(int bookingReservationId)
        //{
        //    _context = new();
        //    return await _context.BookingReservations.Find(bookingReservationId);
        //}

        public async Task<Customer> GetCustomerById(int customerId)
        {
            _context = new();
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public bool DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
