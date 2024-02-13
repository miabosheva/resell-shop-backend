using backend_resell_app.Interfaces;

namespace backend_resell_app.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context) {
            this._context = context;
        }

        public IUserRepository UserRepository => new UserRepository(_context);

        public IProductRepository ProductRepository => new ProductRepository(_context);

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
