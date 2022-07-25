using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersApi.Proxy
{
    public interface ICustomerApi
    {
        [Get("/api/Customers/Validation{id}")]
        Task<bool> Validation(Guid id);
    }
}
