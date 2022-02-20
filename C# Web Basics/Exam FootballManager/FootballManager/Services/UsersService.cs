using System.Linq;

using FootballManager.Data;
using FootballManager.Data.Models;

namespace FootballManager.Services
{
    public class UsersService : IUsersService
    {
        private readonly FootballManagerDbContext data;
        private readonly IPasswordHasher passwordHasher;

        public UsersService(FootballManagerDbContext data, IPasswordHasher passwordHasher)
        {
            this.data = data;
            this.passwordHasher = passwordHasher;
        }

        public void CreateUser(string username, string email, string password)
        {
            var newUser = new User
            {
                Username = username,
                Email = email,
                Password = this.passwordHasher.HashPassword(password)
            };

            this.data.Users.Add(newUser);
            this.data.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var userId = this.data
                .Users
                .Where(u => u.Username == username && u.Password == password)
                .Select(u => u.Id)
                .FirstOrDefault();

            return userId;
        }

        public string GetUsername(string userId)
        {
            var username = this.data
                .Users
                .Where(u => u.Id == userId)
                .Select(u => u.Username)
                .FirstOrDefault();

            return username;
        }

        public bool IsEmailAvailable(string email) 
            => !this.data.Users.Any(u => u.Email == email);

        public bool IsUsernameAvailable(string username) 
            => !this.data.Users.Any(u => u.Username == username);
    }
}
