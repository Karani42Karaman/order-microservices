using CustomersApi.Core;
using CustomersApi.Core.Repositories;
using CustomersApi.Data.Repositories;

namespace CustomersApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly CustomerDBContext _context;

        private CostumerRepository _costumerRepository;
        public ICustomerRepository ICustomerRepository => _costumerRepository ?? new CostumerRepository(_context);

        public UnitOfWork(CustomerDBContext context)
        {
            this._context = context;
        }

        public int CommitAsync()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }  
    }
}
