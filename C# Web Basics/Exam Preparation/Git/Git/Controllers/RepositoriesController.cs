using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        public HttpResponse All()
            => View();

        public HttpResponse Create()
            => View();
    }
}
