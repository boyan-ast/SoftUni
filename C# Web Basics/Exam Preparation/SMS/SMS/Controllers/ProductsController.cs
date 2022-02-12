using System.Linq;
using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Services;
using SMS.ViewModels.Products;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IValidator validator;
        private readonly IProductsService productsService;

        public ProductsController(
            IValidator validator,
            IProductsService productsService)
        {
            this.validator = validator;
            this.productsService = productsService;
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

            this.productsService.CreateProduct(product.Name, product.Price);

            return Redirect("/");
        }
    }
}
