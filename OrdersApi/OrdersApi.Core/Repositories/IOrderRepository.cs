using OrdersApi.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersApi.Core.Repositories
{
    public interface IOrderRepository :IRepositoriy<OrderModel>
    {
        IQueryable<OrderModel> GetAllWithOrderAndAdressAndProduct();
        OrderModel GetWithOrderAndAdressAndProduct(Guid id);
        Task<IEnumerable<OrderModel>> GetAllWithOrderAndAdressAndProduct(Guid id);
    }
}
