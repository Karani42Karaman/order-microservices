using CustomersApi.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersApi.Core.Service
{
    public interface ICustomerService
    {
        void CreateCustomerAsync(CustomerModel model);
        bool UpdateCustomerAsync(CustomerModel model);
        bool RemoveCustomer(Guid id);
        Task<IEnumerable<CustomerModel>> GetAllCustomerAsync();
        ValueTask<CustomerModel> GetCustomerAsync(Guid id);
        bool Validate(Guid id);
        IQueryable<CustomerModel> GetAllWithCutomerAndAdress();
        CustomerModel GetWithCutomerAndAdress(Guid id);
    }
}
