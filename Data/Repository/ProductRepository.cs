using backend_resell_app.Interfaces;
using backend_resell_app.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_resell_app.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductAsync(string username)
        {
            var properties = await _context.Products.ToListAsync();
            return properties;
        }
    }
}
