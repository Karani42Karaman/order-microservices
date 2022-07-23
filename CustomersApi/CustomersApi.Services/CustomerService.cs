using CustomersApi.Core;
using CustomersApi.Core.Model;
using CustomersApi.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersApi.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void CreateCustomerAsync(CustomerModel model)
        {
            try
            {
                _unitOfWork.ICustomerRepository.CreateAsync(model);
                _unitOfWork.CommitAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public Task<IEnumerable<CustomerModel>> GetAllCustomerAsync()
        {
            return _unitOfWork.ICustomerRepository.GetAllAsync();
        }

        public IQueryable<CustomerModel> GetAllWithCutomerAndAdress()
        {
            return _unitOfWork.ICustomerRepository.GetAllWithCutomerAndAdress();
        }

        public ValueTask<CustomerModel> GetCustomerAsync(Guid id)
        {
            return _unitOfWork.ICustomerRepository.GetAsync(id);
        }

        public CustomerModel GetWithCutomerAndAdress(Guid id)
        {
            return _unitOfWork.ICustomerRepository.GetWithCutomerAndAdress(id);
        }

        public bool RemoveCustomer(Guid id)
        {
            CustomerModel model =_unitOfWork.ICustomerRepository.GetWithCutomerAndAdress(id);
            var status = _unitOfWork.ICustomerRepository.Remove(id);
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

        public bool UpdateCustomerAsync(CustomerModel model)
        {
            var status = _unitOfWork.ICustomerRepository.UpdateAsync(model);
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

        /// <summary>
        /// Customer diye bir kayıt varmı  kontorlü yapacak
        /// </summary>
        /// <param name="id">Customer Id </param>
        /// <returns>boolean</returns>
        public bool Validate(Guid id)
        {
            var customer = _unitOfWork.ICustomerRepository.GetAsync(id).Result;
            return customer == null ? false : true;
        }
    }
}
