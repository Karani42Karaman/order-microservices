using CustomersApi.Core;
using CustomersApi.Core.Model;
using CustomersApi.Core.Service;
using System;
using System.Collections.Generic;
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



        public async Task CreateCustomerAsync(CustomerModel model)
        {
            try
            {
                await _unitOfWork.ICustomerRepository.CreateAsync(model);
                await _unitOfWork.CommitAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        public Task<IEnumerable<CustomerModel>> GetAllCustomerAsync()
        {
            return  _unitOfWork.ICustomerRepository.GetAllAsync();
        }

        public ValueTask<CustomerModel> GetCustomerAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomerAsync(CustomerModel model)
        {
            throw new NotImplementedException();
        }
    }
}
