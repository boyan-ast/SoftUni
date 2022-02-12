using System.Collections.Generic;
using SMS.ViewModels.Users;

namespace SMS.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormModel model);
    }
}
