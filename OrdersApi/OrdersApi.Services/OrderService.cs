using OrdersApi.Core;
using OrdersApi.Core.Model;
using OrdersApi.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersApi.Services
{
    public class OrderService : IOrderServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public bool ChangeStatus(Guid id, string status)
        {

            try
            {
                var model = _unitOfWork.IOrderRepository.GetWithOrderAndAdressAndProduct(id);
                model.Status = status;
                model.UpdateAt = DateTime.Now;
                var stat = _unitOfWork.IOrderRepository.UpdateAsync(model);
                var saveStatus = _unitOfWork.CommitAsync();
                if (stat && saveStatus > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }

        public void CreateOrder(OrderModel model)
        {
            try
            {
                _unitOfWork.IOrderRepository.CreateAsync(model);
                _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public Task<IEnumerable<OrderModel>> GetAllOrderAsync()
        {
            return _unitOfWork.IOrderRepository.GetAllAsync();
        }

        public IQueryable<OrderModel> GetAllWithOrderAndAdressAndProduct()
        {
            return _unitOfWork.IOrderRepository.GetAllWithOrderAndAdressAndProduct();
        }

        public Task<IEnumerable<OrderModel>> GetAllWithOrderAndAdressAndProduct(Guid id)
        {
            return _unitOfWork.IOrderRepository.GetAllWithOrderAndAdressAndProduct(id);
        }

        public ValueTask<OrderModel> GetOrderAsync(Guid id)
        {
            return _unitOfWork.IOrderRepository.GetAsync(id);
        }

        public OrderModel GetWithOrderAndAdressAndProduct(Guid id)
        {
            return _unitOfWork.IOrderRepository.GetWithOrderAndAdressAndProduct(id);
        }

        public bool RemoveOrder(Guid id)
        {
            var status = _unitOfWork.IOrderRepository.Remove(id);
            var saveStatus = _unitOfWork.CommitAsync();
            if (status && saveStatus > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateOrder(OrderModel model)
        {
            try
            {
                var status = _unitOfWork.IOrderRepository.UpdateAsync(model);
                var saveStatus = _unitOfWork.CommitAsync();
                if (status && saveStatus > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }
    }
}
