using System.Linq;

using SMS.Data;
using SMS.Data.Models;

namespace SMS.Services
{
    public class UsersService : IUsersService
    {
        private readonly SMSDbContext data;
        private readonly IPasswordHasher passwordHasher;

        public UsersService(SMSDbContext data, IPasswordHasher passwordHasher)
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
                Password = this.passwordHasher.HashPassword(password),
                Cart = new Cart()
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
