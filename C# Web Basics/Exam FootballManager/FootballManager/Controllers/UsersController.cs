using System.Linq;

using FootballManager.Services;
using FootballManager.ViewModels.Users;

using MyWebServer.Controllers;
using MyWebServer.Http;

namespace FootballManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly IUsersService usersService;

        public UsersController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            IUsersService usersService)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.usersService = usersService;
        }

        public HttpResponse Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterFormModel model)
        {
            var errors = this.validator.ValidateUser(model);

            if (!this.usersService.IsUsernameAvailable(model.Username))
            {
                errors.Add($"User '{model.Username}' already exists!");
            }

            if (!this.usersService.IsEmailAvailable(model.Username))
            {
                errors.Add($"User with email '{model.Email}' already exists!");
            }

            if (errors.Any())
            {
                return Error(errors);
            }

            this.usersService.CreateUser(model.Username, model.Email, model.Password);

            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginFormModel model)
        {
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.usersService.GetUserId(model.Username, hashedPassword);

            if (userId == null)
            {
                return Error("Wrong username or password.");
            }

            this.SignIn(userId);

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }

    }
}
