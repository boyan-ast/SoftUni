using System.Linq;
using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Services;
using SMS.ViewModels.Products;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly IProductsService productsService;

        public CartsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }


        [Authorize]
        public HttpResponse Details()
        {
            var products = this.productsService
                .GetUserProducts(User.Id)
                .Select(p => new ProductListingViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price.ToString("f2")
                })
                .ToList();

            return View(products);
        }

        [Authorize]
        public HttpResponse AddProduct(string productId)
        {
            this.productsService.AddProductToCart(User.Id, productId);

            return Redirect("/Carts/Details");
        }

        [Authorize]
        public HttpResponse Buy()
        {
            this.productsService.BuyProducts(User.Id);

            return Redirect("/");
        }

    }
}
