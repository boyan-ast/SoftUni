namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Services;
    using SMS.ViewModels.Products;
    using SMS.ViewModels.Users;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IProductsService productsService;

        public HomeController(
            IUsersService usersService,
            IProductsService productsService)
        {
            this.usersService = usersService;
            this.productsService = productsService;
        }

        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                string username = this.usersService.GetUsername(User.Id);

                var model = new HomePageViewModel
                {
                    Username = username,
                    Products = this.productsService
                        .GetAllProducts()
                        .Select(p => new ProductListingViewModel
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Price = p.Price.ToString("f2")
                        })
                        .ToArray()
                };

                return View(model, "/Home/IndexLoggedIn");
            }

            return View();
        }

    }
}