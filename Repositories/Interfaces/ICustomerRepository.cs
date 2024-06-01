
using Repositories.Entities;

namespace Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Customer? GetUserAccount(string email, string password);
    }
}
