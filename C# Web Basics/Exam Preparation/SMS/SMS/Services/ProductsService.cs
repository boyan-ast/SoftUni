using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Models;

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

            product.CartId = user.CartId;

            this.data.SaveChanges();
        }

        public void BuyProducts(string userId)
        {
            var cartId = this.data.Users.Find(userId).CartId;
            var products = this.data.Products.Where(p => p.CartId == cartId).ToList();

            foreach (var product in products)
            {
                product.CartId = null;
            }

            this.data.SaveChanges();
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

        public ICollection<Product> GetUserProducts(string userId)
        {
            var user = this.data.Users.Find(userId);

            var products = this.data.Products.Where(p => p.CartId == user.CartId).ToList();

            return products;
        }
    }
}
