using System;
using System.Linq;

using Git.Data;
using Git.Data.Models;
using Git.Services;
using Git.ViewModels.Repositories;

using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public RepositoriesController(
            ApplicationDbContext data,
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        public HttpResponse All()
        {
            var repositories = this.data
                .Repositories
                .Where(r => r.IsPublic)
                .Select(r => new RepositoryViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToString("r"),
                    CommitsCount = r.Commits.Count()
                })
                .ToList();

            return View(repositories);
        }

        [Authorize]
        public HttpResponse Create()
            => View();


        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateRepositoryFormModel model)
        {
            var errors = this.validator.ValidateRepository(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            var newRepository = new Repository
            {
                Name = model.Name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = model.RepositoryType == "Public",
                OwnerId = this.User.Id
            };

            this.data.Repositories.Add(newRepository);

            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }
    }
}
