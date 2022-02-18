using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using SMS.Data;
using SMS.Data.Models;
using SMS.Models.Products;

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
            var product = this.GetProductById(productId);

            var user = this.data.Users.Find(userId);

            product.CartId = user.CartId;

            this.data.SaveChanges();
        }

        public Product GetProductById(string productId)
        {
            return this.data.Products.Find(productId);
        }

        public void CreateProduct(string name, decimal price)
        {
            var product = new Product
            {
                Name = name,
                Price = price
            };

            this.data.Products.Add(product);
            this.data.SaveChanges();
        }

        public List<ProductListingViewModel> GetAll()
        {
            var products = this.data
                .Products
                .Select(p => new ProductListingViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.ToString("f2")
                })
                .ToList();

            return products;
        }

        public List<ProductListingViewModel> GetUserProducts(string userId)
        {
            var products = this.data
                .Users
                .Include(u => u.Cart.Products)
                .FirstOrDefault(u => u.Id == userId)
                .Cart
                .Products
                .Select(p => new ProductListingViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.ToString("f2")
                })
                .ToList();

            return products;
        }

        public void BuyProducts(string userId)
        {
            this.data.Users
                .Include(u => u.Cart.Products)
                .FirstOrDefault(u => u.Id == userId)
                .Cart
                .Products
                .Clear();

            this.data.SaveChanges();
        }
    }
}
