using System.Linq;
using MUSACA.Data;
using MUSACA.Data.Models;
using MUSACA.Data.Models.Enums;
using MUSACA.Services;
using MUSACA.ViewModels.Home;
using MUSACA.ViewModels.Products;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace MUSACA.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public ProductsController(IValidator validator, ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Order(CreateOrderFormModel model)
        {
            var productName = model.Product;

            var product = this.data
                .Products
                .Where(p => p.Name.ToLower() == productName.ToLower())
                .FirstOrDefault();

            if (product == null)
            {
                return Error($"Product {productName} does not exist!");
            }

            var newOrder = new Order
            {
                CashierId = this.User.Id,
                Product = product,
                Status = Status.Active
            };

            this.data.Orders.Add(newOrder);
            this.data.SaveChanges();

            return Redirect("/");
        }

        [Authorize]
        public HttpResponse All()
        {
            var products = this.data
                .Products
                .Select(p => new ProductListingViewModel
                {
                    Name = p.Name,
                    Price = p.Price.ToString("f2")
                })
                .ToList();

            return View(products);
        }

        [Authorize]
        public HttpResponse Create()
            => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateProductFormModel model)
        {
            var errors = this.validator.ValidateProduct(model);

            if (this.data.Products.Any(p => p.Name.ToLower() == model.Name.ToLower()))
            {
                errors.Add($"Product {model.Name} already exists!");
            }

            if (errors.Any())
            {
                return Error(errors);
            }

            var newProduct = new Product
            {
                Name = model.Name,
                Price = model.Price
            };

            this.data.Products.Add(newProduct);
            this.data.SaveChanges();

            return Redirect("/Products/All");
        }
    }
}
