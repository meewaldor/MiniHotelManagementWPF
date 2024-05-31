
using Repositories;
using Repositories.Entities;

namespace Services
{
    public class CustomerService
    {
        // Check login
        public Customer? CheckLogin(string username, string password)
        {
            return CustomerRepository.Instance.GetUserAccount(username, password);
        }
    }
}
