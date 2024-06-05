
using Repositories.Entities;

namespace Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetUserAccount(string email, string password);
        Task<IEnumerable<Customer>> GetAllCustomersConfig();
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);
    }
}
