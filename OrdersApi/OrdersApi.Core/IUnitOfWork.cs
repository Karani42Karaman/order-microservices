using OrdersApi.Core.Repositories;
using System;


namespace OrdersApi.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository IOrderRepository { get; }
        int CommitAsync();
    }
}
