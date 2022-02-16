using System;
using System.Linq;
using Git.Models.Repositories;
using Git.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IValidator validator;
        private readonly IRepositoryService repositoryService;

        public RepositoriesController(
            IValidator validator,
            IRepositoryService repositoryService)
        {
            this.validator = validator;
            this.repositoryService = repositoryService;
        }

        public HttpResponse All()
        {
            var repositories = this.repositoryService.GetAllPublicRepositories().ToList();

            return View(repositories);
        }


        [Authorize]
        public HttpResponse Create()
        {
            if (!User.IsAuthenticated)
            {
                return Unauthorized();
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateRepositoryFormModel repository)
        {
            var errors = this.validator.ValidateRepository(repository);

            if (errors.Any())
            {
                return Error(errors);
            }

            try
            {
                this.repositoryService.CreateRepository(repository.Name, repository.RepositoryType, User.Id);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }

            return Redirect("/Repositories/All");
        }
    }
}
