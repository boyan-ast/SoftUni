using System.Linq;
using MyWebServer.Http;
using MyWebServer.Controllers;
using MUSACA.ViewModels.Home;
using MUSACA.Services;
using MUSACA.Data;
using MUSACA.Data.Models.Enums;

namespace MUSACA.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ApplicationDbContext data;

        public HomeController(IUsersService usersService, ApplicationDbContext data)
        {
            this.usersService = usersService;
            this.data = data;
        }

        public HttpResponse Index()
        {
            var model = new HomePageViewModel
            {
                Username = this.usersService.GetUsername(User.Id)                
            };

            if (User.IsAuthenticated)
            {
                model.Orders = this.data
                    .Orders
                    .Where(o => o.CashierId == User.Id && o.Status == Status.Active)
                    .Select(o => new OrderListingViewModel
                    {
                        ProductName = o.Product.Name,
                        ProductPrice = o.Product.Price.ToString("f2")
                    })
                    .ToList();

                model.TotalSum = this.data
                    .Orders
                    .Where(o => o.CashierId == User.Id && o.Status == Status.Active)
                    .Sum(o => o.Product.Price)
                    .ToString("f2");

                return View(model);
            }

            return this.View(model);
        }
    }
}
