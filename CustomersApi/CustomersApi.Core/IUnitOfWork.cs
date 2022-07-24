using CustomersApi.Core.Repositories;
using System;

namespace CustomersApi.Core
{
    public interface IUnitOfWork:IDisposable
    {
        ICustomerRepository ICustomerRepository { get;}
        int CommitAsync();
    }
}
