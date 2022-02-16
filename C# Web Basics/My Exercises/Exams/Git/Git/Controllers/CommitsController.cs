using System.Linq;
using Git.Models.Commits;
using Git.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly IValidator validator;
        private readonly IRepositoryService repositoryService;
        private readonly ICommitsService commitsService;

        public CommitsController(
            IValidator validator,
            IRepositoryService repositoryService,
            ICommitsService commitsService)
        {
            this.validator = validator;
            this.repositoryService = repositoryService;
            this.commitsService = commitsService;
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repositoryModel = this.repositoryService.GetRepositoryById(id);

            if (repositoryModel == null)
            {
                return Error("Repository does not exist.");
            }

            return View(repositoryModel);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateCommitFormModel commit)
        {
            var errors = this.validator.ValidateCommit(commit);

            if (errors.Any())
            {
                return Error(errors);
            }

            this.commitsService.CreateCommit(commit.Description, User.Id, commit.Id);

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var commits = this.commitsService.GetAll(User.Id).ToList();

            return View(commits);
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            this.commitsService.RemoveCommit(id, User.Id);

            return Redirect("/Commits/All");
        }
    }
}
