using System.Collections.Generic;
using SharedTrip.ViewModels.Users;

namespace SharedTrip.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormModel model);

    }
}
