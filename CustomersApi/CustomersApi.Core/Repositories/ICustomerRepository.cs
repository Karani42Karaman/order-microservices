using CustomersApi.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomersApi.Core.Repositories
{
    public interface ICustomerRepository : IRepositoriy<CustomerModel>
    {
        IQueryable<CustomerModel> GetAllWithCutomerAndAdress();
         CustomerModel GetWithCutomerAndAdress(Guid id);
    }
}
