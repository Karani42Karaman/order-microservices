using Microsoft.EntityFrameworkCore;
using OrdersApi.Core.Model;
using OrdersApi.Core.Repositories;
using System;
using System.Linq;


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

        public IQueryable<OrderModel> GetAllWithOrderAndAdressAndProduct()
        {
            return OrderDBContext.OrderModel.Include(x=>x.Address).Include(x=>x.Product);
        }

        public OrderModel GetWithCutomerAndOrder(Guid id)
        {
            return OrderDBContext.OrderModel.Where(x => x.Id == id).Include(x => x.Address).FirstOrDefault();
        }
    }
}
