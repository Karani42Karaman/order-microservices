using OrdersApi.Core.Model;
using System;
using System.Linq;


namespace OrdersApi.Core.Repositories
{
    public interface IOrderRepository :IRepositoriy<OrderModel>
    {
        IQueryable<OrderModel> GetAllWithOrderAndAdressAndProduct();
        OrderModel GetWithCutomerAndOrder(Guid id);
    }
}
