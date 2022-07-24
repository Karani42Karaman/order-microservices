using OrdersApi.Core;
using OrdersApi.Core.Repositories;
using OrdersApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly OrderDBContext _context;

        private OrderRepository _orderRepository;

        public IOrderRepository IOrderRepository => _orderRepository ?? new OrderRepository(_context);

        public UnitOfWork(OrderDBContext context)
        {
            this._context = context;
        }

        public int CommitAsync()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
