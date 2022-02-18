using System.Collections.Generic;
using SMS.Data.Models;
using SMS.Models.Products;

namespace SMS.Services
{
    public interface IProductsService
    {
        List<ProductListingViewModel> GetAll();

        List<ProductListingViewModel> GetUserProducts(string userId);

        Product GetProductById(string productId);

        void CreateProduct(string name, decimal price);

        void AddProductToCart(string userId, string productId);

        void BuyProducts(string userId);
    }
}
