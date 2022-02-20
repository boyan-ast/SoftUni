using System.Collections.Generic;
using System.Text.RegularExpressions;

using FootballManager.ViewModels.Players;
using FootballManager.ViewModels.Users;

using static FootballManager.Data.DataConstants;

namespace FootballManager.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidatePlayer(AddPlayerFormModel model)
        {
            var errors = new List<string>();

            if (model.FullName == null || model.FullName.Length < DefaultMinLength || model.FullName.Length > PlayerNameMaxLength)
            {
                errors.Add($"Player Full Name must be between {DefaultMinLength} and {PlayerNameMaxLength} characters long.");
            }

            if (string.IsNullOrWhiteSpace(model.ImageUrl))
            {
                errors.Add("Image URL is required.");
            }

            if (model.Position == null)
            {
                errors.Add("Position is required.");
            }

            if (model.Position != PlayerGoalkeeper && 
                model.Position != PlayerRightFullback &&
                model.Position != PlayerLeftFullback &&
                model.Position != PlayerCenterBack &&
                model.Position != PlayerDefender &&
                model.Position != PlayerStriker &&
                model.Position != PlayerWinger)
            {
                errors.Add($"Position '{model.Position}' is not valid.");
            }

            if (model.Speed < DefaultMinValue || model.Speed > DefaultMaxValue)
            {
                errors.Add($"Speed must be between {DefaultMinValue} and {DefaultMaxValue}.");
            }

            if (model.Endurance < DefaultMinValue || model.Endurance > DefaultMaxValue)
            {
                errors.Add($"Endurance must be between {DefaultMinValue} and {DefaultMaxValue}.");
            }

            if (string.IsNullOrWhiteSpace(model.Description))
            {
                errors.Add("Description is required.");
            }

            if (model.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"Description must be maximum {DescriptionMaxLength} characters long.");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterFormModel model)
        {
            var errors = new List<string>();

            if (model.Username == null || model.Username.Length < DefaultMinLength || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username must be between {DefaultMinLength} and {DefaultMaxLength} characters long.");
            }

            if (model.Email == null || model.Email.Length < EmailMinLength || model.Email.Length > EmailMaxLength)
            {
                errors.Add($"Email must be between {EmailMinLength} and {EmailMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, EmailRegexPattern))
            {
                errors.Add($"Email '{model.Email}' is not a valid email address.");
            }

            if (model.Password == null || model.Password.Length < DefaultMinLength || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"Password must be between {DefaultMinLength} and {DefaultMaxLength} characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and Confirm Password are not the same.");
            }

            return errors;
        }              
    }
}

