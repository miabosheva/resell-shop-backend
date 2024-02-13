﻿using backend_resell_app.Models;

namespace backend_resell_app.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductAsync(string username);
        void AddProduct(Product product);
        void DeleteProduct(int id);
    }
}