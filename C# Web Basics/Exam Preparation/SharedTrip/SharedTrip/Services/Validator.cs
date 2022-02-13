using System.Collections.Generic;
using System.Text.RegularExpressions;
using SharedTrip.ViewModels.Trips;
using SharedTrip.ViewModels.Users;

using static SharedTrip.Data.DataConstants;

namespace SharedTrip.Services
{
    public class Validator : IValidator
    {
        private readonly ITripsService tripsService;

        public Validator(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public ICollection<string> ValidateTrip(AddTripFormModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                errors.Add("Start Point must not be null or white space.");
            }

            if (string.IsNullOrEmpty(model.EndPoint))
            {
                errors.Add("End Point must not be null or white space.");
            }

            if (string.IsNullOrEmpty(model.DepartureTime))
            {
                errors.Add("Departure Time must not be empty.");
            }

            if (model.Seats < SeatsMinValue || model.Seats > SeatsMaxValue)
            {
                errors.Add($"Seats number must be between {SeatsMinValue} and {SeatsMaxValue}.");
            }

            if (model.Description == null || model.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"Description must be maximum {DescriptionMaxLength} characters long.");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterFormModel model)
        {
            var errors = new List<string>();

            if (model.Username == null || model.Username.Length < UsernameMinLength || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username must be between {UsernameMinLength} and {DefaultMaxLength} characters long!");
            }

            if (!Regex.IsMatch(model.Email, EmailPattern))
            {
                errors.Add($"Email {model.Email} is not valid!");
            }

            if (model.Password.Length < PasswordMinLength || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"Password must be between {PasswordMinLength} and {DefaultMaxLength} characters long!");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("The two passwords don't match!");
            }

            return errors;
        }

        public ICollection<string> ValidateUserJoiningTrip(string userId, string tripId)
        {
            var errors = new List<string>();

            if (this.tripsService.UserHasJoinedTrip(userId, tripId))
            {
                errors.Add($"User with id {userId} has already joined trip with id {tripId}");
            }

            if (this.tripsService.GetFreeSeats(tripId) == 0)
            {
                errors.Add($"No more free seats for this trip.");
            }

            return errors;
        }
    }
}

