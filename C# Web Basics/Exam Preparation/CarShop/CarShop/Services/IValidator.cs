using System.Collections.Generic;

using CarShop.ViewModels.Car;
using CarShop.ViewModels.Issues;
using CarShop.ViewModels.Users;

namespace CarShop.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormModel model);

        ICollection<string> ValidateCar(AddCarFormModel model);

        ICollection<string> ValidateIssue(AddIssueFormModel model);
    }
}
