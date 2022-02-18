using System.Linq;

using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Models.Products;
using SMS.Services;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IValidator validator;
        private readonly IProductsService productService;

        public ProductsController(
            IValidator validator,
            IProductsService productService)
        {
            this.validator = validator;
            this.productService = productService;
        }

        [Authorize]
        public HttpResponse Create()
            => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateProductFormModel product)
        {
            var errors = this.validator.ValidateProduct(product);

            if (errors.Any())
            {
                return Error(errors);
            }

            this.productService.CreateProduct(product.Name, product.Price);

            return Redirect("/");
        }
    }
}
