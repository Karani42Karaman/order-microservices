using CustomersApi.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace CustomersApi.Core
{
    public interface IUnitOfWork:IDisposable
    {
        ICustomerRepository ICustomerRepository { get;}
        Task<int> CommitAsync();
    }
}
