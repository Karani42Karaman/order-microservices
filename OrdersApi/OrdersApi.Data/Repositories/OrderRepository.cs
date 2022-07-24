using Microsoft.EntityFrameworkCore;
using OrdersApi.Core.Model;
using OrdersApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersApi.Data.Repositories
{
    public class OrderRepository : Repository<OrderModel>, IOrderRepository
    {

        public OrderRepository(OrderDBContext context) : base(context)
        {
        }
        private OrderDBContext OrderDBContext
        {
            get { return Context as OrderDBContext; }
        }

        public Task<IEnumerable<OrderModel>> GetAllWithOrderAndAdressAndProduct(Guid id)
        {
            return (Task<IEnumerable<OrderModel>>)OrderDBContext.OrderModel.Include(x => x.Address).Include(x => x.Product).Where(x=>x.Id == id);
        }

        public IQueryable<OrderModel> GetAllWithOrderAndAdressAndProduct()
        {
            return OrderDBContext.OrderModel.Include(x=>x.Address).Include(x=>x.Product);
        }

        public OrderModel GetWithOrderAndAdressAndProduct(Guid id)
        {
            return OrderDBContext.OrderModel.Where(x => x.Id == id).Include(x => x.Address).Include(x => x.Product).FirstOrDefault();
        }
    }
}
