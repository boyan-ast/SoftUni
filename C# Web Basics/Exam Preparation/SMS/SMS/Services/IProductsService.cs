using System.Collections.Generic;
using SMS.Data.Models;

namespace SMS.Services
{
    public interface IProductsService
    {
        void CreateProduct(string name, decimal price);

        ICollection<Product> GetAllProducts();

        ICollection<Product> GetUserProducts(string userId);

        void AddProductToCart(string userId, string productId);

        void BuyProducts(string userId);
    }
}
