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

        public bool IsMechanic(string userId)
        {
            var user = this.data
                .Users
                .FirstOrDefault(u => u.Id == userId);

            return user.IsMechanic;
        }

        public bool OwnsCar(string userId, string carId)
        {
            return this.data.Cars.Any(c => c.Id == carId && c.OwnerId == userId);
        }
    }
}
