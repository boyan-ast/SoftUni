using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        public HttpResponse All()
            => View();


        [Authorize]
        public HttpResponse Create()
            => View();
    }
}
