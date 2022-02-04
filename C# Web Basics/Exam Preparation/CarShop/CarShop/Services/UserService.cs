using System.Linq;

using CarShop.Data;

namespace CarShop.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext data;

        public UserService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public bool isMechanic(string userId)
        {
            var user = this.data
                .Users
                .FirstOrDefault(u => u.Id == userId);

            return user.IsMechanic;
        }
    }
}
