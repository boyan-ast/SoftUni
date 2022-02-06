using System.Linq;

using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services;
using CarShop.ViewModels.Users;

using MyWebServer.Controllers;
using MyWebServer.Http;

using static CarShop.Data.DataConstants;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly ApplicationDbContext data;

        public UsersController(
            IValidator validator, 
            IPasswordHasher passwordHasher,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.data = data;
        }

        public HttpResponse Register()
            => View();

        [HttpPost]
        public HttpResponse Register(RegisterFormModel model)
        {
            var errors = this.validator.ValidateUser(model);

            if (this.data.Users.Any(u => u.Username == model.Username))
            {
                errors.Add($"User '{model.Username}' already exists!");
            }

            if (this.data.Users.Any(u => u.Email == model.Email))
            {
                errors.Add($"User with email '{model.Email}' already exists!");
            }

            if (errors.Any())
            {
                return Error(errors);
            }

            var newUser = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = this.passwordHasher.HashPassword(model.Password),
                IsMechanic = model.UserType == UserTypeMechanic
            };

            this.data.Users.Add(newUser);
            this.data.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
            => View();


        [HttpPost]
        public HttpResponse Login(LoginFormModel model)
        {
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.data
                .Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return Error("Wrong username or password!");
            }

            this.SignIn(userId);

            return Redirect("/Cars/All");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
