using System;
using System.Linq;
using MUSACA.Data;
using MUSACA.Data.Models;
using MUSACA.Data.Models.Enums;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace MUSACA.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext data;

        public OrdersController(ApplicationDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public HttpResponse Cashout()
        {
            var orders = this.data
                   .Orders
                   .Where(o => o.CashierId == User.Id && o.Status == Status.Active)
                   .ToList();

            if (orders.Any())
            {
                var newReceipt = new Receipt
                {
                    IssuedOn = DateTime.UtcNow,
                    Orders = orders,
                    CashierId = this.User.Id
                };

                foreach (var order in orders)
                {
                    order.Status = Status.Completed;
                }

                this.data.Receipts.Add(newReceipt);
                this.data.SaveChanges();
            }

            return Redirect("/");
        }
    }
}
