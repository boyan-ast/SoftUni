using System.Collections.Generic;

using FootballManager.ViewModels.Players;
using FootballManager.ViewModels.Users;

namespace FootballManager.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormModel model);

        ICollection<string> ValidatePlayer(AddPlayerFormModel model);
    }
}
