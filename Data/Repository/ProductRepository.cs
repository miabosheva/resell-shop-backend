using backend_resell_app.Data.Dto;
using backend_resell_app.Interfaces;
using backend_resell_app.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace backend_resell_app.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProduct(ProductListDto product, int userId, ProductConditionType productCondition, ProductType productType)
        {

                var newProduct = new Product
                {
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    ConditionType = productCondition,
                    ConditionTypeId = productCondition.Id,
                    Year = product.Year,
                    Size = product.Size,
                    ProductType = productType,
                    ProductTypeId = productType.Id,
                    Auhtor = userId
                };

                _context.Products.Add(newProduct);
                await _context.SaveChangesAsync();
                return newProduct;
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductAsync(int id)
        {
            var properties = await _context.Products.Include(p=>p.ProductType).Include(p => p.ConditionType).Where(p=> p.Auhtor == id).ToListAsync();
            return properties;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var properties = await _context.Products.Include(p => p.ProductType).Include(p => p.ConditionType).ToListAsync();
            return properties;
        }

        public async Task<ProductConditionType> GetConditionTypeObjectFromName(string name)
        {
            return await _context.ConditionTypes.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<ProductType> GetTypeObjectFromName(string name)
        {
            return await _context.ProductTypes.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
