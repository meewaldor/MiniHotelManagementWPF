﻿
using Repositories.Entities;

namespace Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Customer? GetUserAccount(string email, string password);

        Task<IEnumerable<Customer>> GetAllCustomersConfig();

        Task<IEnumerable<Customer>> GetCustomerBySearchValue(string searchValue);
    }
}
