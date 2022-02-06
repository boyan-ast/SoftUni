using System.Linq;

using Git.Data;
using Git.ViewModels.Commits;

using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ApplicationDbContext data;

        public CommitsController(ApplicationDbContext data)
        {
            this.data = data;
        }

        public HttpResponse All()
            => View();

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repositoryViewModel = this.data
                .Repositories
                .Where(r => r.Id == id)
                .Select(r => new RepositoryCommitViewModel
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .FirstOrDefault();

            return View(repositoryViewModel);
        }
    }
}
