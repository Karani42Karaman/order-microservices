using OrdersApi.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersApi.Core.Service
{
    public interface IOrderServices
    {
        void CreateOrder(OrderModel model);
        bool UpdateOrder(OrderModel model);
        bool RemoveOrder(Guid id);
        Task<IEnumerable<OrderModel>> GetAllOrderAsync();
        ValueTask<OrderModel> GetOrderAsync(Guid id);
        IQueryable<OrderModel> GetAllWithOrderAndAdressAndProduct();
        OrderModel GetWithOrderAndAdressAndProduct(Guid id);
        Task<IEnumerable<OrderModel>> GetAllWithOrderAndAdressAndProduct(Guid id);
        bool ChangeStatus(Guid id,string status);
    }
}
