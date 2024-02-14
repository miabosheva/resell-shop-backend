using backend_resell_app.Data.Dto;
using backend_resell_app.Models;

namespace backend_resell_app.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> AddProduct(ProductListDto product, int userId, ProductConditionType productCondition, ProductType productType);
        Task<ProductConditionType> GetConditionTypeObjectFromName(string name);
        Task<ProductType> GetTypeObjectFromName(string name);
        Task<Product> DeleteProduct(int id);
    }
}
