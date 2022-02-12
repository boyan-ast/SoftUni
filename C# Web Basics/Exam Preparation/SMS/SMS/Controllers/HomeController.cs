namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Services;

    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                var username = this.usersService.GetUsername(User.Id);

                return View(username, "/Home/IndexLoggedIn");
            }

            return View();
        }

    }
}