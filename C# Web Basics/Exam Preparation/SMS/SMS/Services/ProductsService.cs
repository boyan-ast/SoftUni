using SMS.Data;
using SMS.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services
{
    public class ProductsService : IProductsService
    {
        private readonly SMSDbContext data;

        public ProductsService(SMSDbContext data)
        {
            this.data = data;
        }

        public void AddProductToCart(string userId, string productId)
        {
            var user = this.data
                .Users
                .Find(userId);

            var product = this.data
                .Products
                .Find(productId);

            user.Cart.Products.Add(product);
        }

        public void CreateProduct(string name, decimal price)
        {
            var newProduct = new Product
            {
                Name = name,
                Price = price
            };

            this.data.Products.Add(newProduct);
            this.data.SaveChanges();
        }

        public ICollection<Product> GetAllProducts()
            => this.data.Products.ToList();
    }
}
