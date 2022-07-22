using CustomersApi.Core.Model;
using CustomersApi.Core.Repositories;


namespace CustomersApi.Data.Repositories
{
    public class CostumerRepository : Repository<CustomerModel>, ICustomerRepository
    {
        public CostumerRepository(CustomerDBContext context) : base(context)
        {
        }
    }
}
