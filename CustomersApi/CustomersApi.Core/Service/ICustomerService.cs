using CustomersApi.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CustomersApi.Core.Service
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(CustomerModel model);
        Task UpdateCustomerAsync(CustomerModel model);
        void RemoveCustomer(Guid id);
        Task<IEnumerable<CustomerModel>> GetAllCustomerAsync();
        ValueTask<CustomerModel> GetCustomerAsync(Guid id);
    }
}
