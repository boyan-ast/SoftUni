using CarShop.ViewModels.Car;
using CarShop.ViewModels.Users;
using System.Collections.Generic;

namespace CarShop.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormModel model);
        ICollection<string> ValidateCar(AddCarFormModel model);
    }
}
