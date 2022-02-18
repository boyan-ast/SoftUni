namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Models.Home;
    using SMS.Services;

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
                var username = this.usersService.GetUsername(User.Id);
                var products = this.productsService.GetAll();

                var userHomepageModel = new UserHomepageViewModel
                {
                    Username = username,
                    Products = products,
                };

                return View(userHomepageModel, "/Home/IndexLoggedIn");
            }

            return this.View();
        }
    }
}