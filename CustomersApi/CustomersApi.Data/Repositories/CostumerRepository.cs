using CustomersApi.Core.Model;
using CustomersApi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CustomersApi.Data.Repositories
{
    public class CostumerRepository : Repository<CustomerModel>, ICustomerRepository
    {
        public CostumerRepository(CustomerDBContext context) : base(context)
        {
        }

        private CustomerDBContext CustomerDBContext
        {
            get { return Context as CustomerDBContext; }
        }

        public IQueryable<CustomerModel> GetAllWithCutomerAndAdress()
        {        
            return CustomerDBContext.CustomerModel.Include(x => x.Address) ;
        }

        public CustomerModel GetWithCutomerAndAdress(Guid id)
        {
            return CustomerDBContext.CustomerModel.Where(x=>x.Id==id).Include(x => x.Address).FirstOrDefault();
        }

       
    }
}
