using System;
using System.Linq;

using Git.Data;
using Git.Data.Models;
using Git.Services;
using Git.ViewModels.Commits;

using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public CommitsController(
            ApplicationDbContext data,
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

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

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CommitFormModel model)
        {
            var errors = this.validator.ValidateCommit(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            var newCommit = new Commit
            {
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = this.User.Id,
                RepositoryId = model.Id
            };

            this.data.Commits.Add(newCommit);

            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var userCommits = this.data
                .Commits
                .Where(c => c.CreatorId == this.User.Id)
                .Select(c => new CommitListingViewModel
                {
                    Id = c.Id,
                    Repository = c.Repository.Name,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToString("r")
                })
                .ToList();

            return View(userCommits);
        }

        public HttpResponse Delete(string id)
        {
            var commit = this.data.Commits.Find(id);

            if (commit.CreatorId != this.User.Id)
            {
                return Unauthorized();
            }

            this.data.Commits.Remove(commit);

            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }
    }
}
