using System.Collections.Generic;
using MUSACA.ViewModels.Users;

namespace MUSACA.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormModel model);

    }
}
