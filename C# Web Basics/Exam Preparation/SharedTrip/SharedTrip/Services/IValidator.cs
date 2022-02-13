using System.Collections.Generic;
using SharedTrip.Data.Models;
using SharedTrip.ViewModels.Trips;
using SharedTrip.ViewModels.Users;

namespace SharedTrip.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormModel model);

        ICollection<string> ValidateTrip(AddTripFormModel model);

    }
}
