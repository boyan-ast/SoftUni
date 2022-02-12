using SMS.Data.Models;
using System.Collections.Generic;

namespace SMS.Services
{
    public interface IProductsService
    {
        void CreateProduct(string name, decimal price);

        ICollection<Product> GetAllProducts();

        void AddProductToCart(string userId, string productId);
    }
}
