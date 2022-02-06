using System.Linq;

using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services;
using CarShop.ViewModels.Issues;

using MyWebServer.Controllers;
using MyWebServer.Http;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IUserService userService;
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public IssuesController(
            IUserService userService,
            ApplicationDbContext data,
            IValidator validator)
        {
            this.userService = userService;
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Add(string carId)
        {
            var issueViewModel = new AddIssueViewModel
            {
                CarId = carId
            };

            return View(issueViewModel);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddIssueFormModel model)
        {
            var errors = this.validator.ValidateIssue(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            var newIssue = new Issue
            {
                Description = model.Description,
                IsFixed = false,
                CarId = model.CarId
            };

            this.data.Issues.Add(newIssue);

            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={model.CarId}");
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            if (!this.UserCanAccessCar(carId))
            {
                return Unauthorized();
            }

            var carIssues = this.data
                .Cars
                .Where(c => c.Id == carId)
                .Select(c => new CarIssueViewModel
                {
                    Id = c.Id,
                    Year = c.Year,
                    Model = c.Model,
                    Issues = c.Issues
                        .Select(i => new IssueViewModel
                        {
                            Id = i.Id,
                            Description = i.Description,
                            IsFixed = i.IsFixed
                        })
                        .ToList()
                })
                .FirstOrDefault();

            return View(carIssues);
        }

        [Authorize]
        public HttpResponse Fix(string issueId, string carId)
        {
            bool isUserMechanic = this.userService.IsMechanic(this.User.Id);

            if (!isUserMechanic)
            {
                return Error("Only mechanics can fix issues!");
            }

            bool isIssueFixed = this.data
                .Issues
                .FirstOrDefault(i => i.Id == issueId)
                .IsFixed;

            if (isIssueFixed)
            {
                return Error("Issue is already fixed!");
            }

            this.data
                .Issues
                .FirstOrDefault(i => i.Id == issueId)
                .IsFixed = true;

            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            var issue = this.data.Issues.FirstOrDefault(i => i.Id == issueId);

            this.data.Remove(issue);

            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        private bool UserCanAccessCar(string carId)
        {
            var userIsMechanic = this.userService.IsMechanic(this.User.Id);

            if (!userIsMechanic)
            {
                var userOwnsCar = this.userService.OwnsCar(this.User.Id, carId);

                if (!userOwnsCar)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
