using MyWebServer.Controllers;
using MyWebServer.Http;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        [Authorize]
        public HttpResponse Add()
            => View();

        [Authorize]
        public HttpResponse CarIssues()
            => View();
    }
}
