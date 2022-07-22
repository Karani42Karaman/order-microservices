using CustomersApi.Core;
using CustomersApi.Core.Repositories;
using CustomersApi.Data.Repositories;
using System.Threading.Tasks;

namespace CustomersApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly CustomerDBContext _context;

        private   CostumerRepository _costumerRepository;
        public ICustomerRepository ICustomerRepository => _costumerRepository ?? new CostumerRepository(_context);

        public UnitOfWork(CustomerDBContext context)
        {
            this._context = context;
        }


        public async Task<int> CommitAsync()
        {
        var a =     await _context.SaveChangesAsync();
            return a;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
