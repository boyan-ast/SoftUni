using System.Collections.Generic;
using System.Text.RegularExpressions;

using CarShop.ViewModels.Users;

using static CarShop.Data.DataConstants;

namespace CarShop.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null || user.Username.Length < UsernameMinLength || user.Username.Length > DefaultMaxLength)
            {
                errors.Add($"The username '{user.Username}' is not valid. Its length must be between {UsernameMinLength} and {DefaultMaxLength} symbols!");
            }

            if (user.Email == null || !Regex.IsMatch(user.Email, EmailPattern))
            {
                errors.Add($"Email '{user.Email}' is not valid!");
            }

            if (user.Password == null || user.Password.Length < PasswordMinLength || user.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The password must be between {PasswordMinLength} and {DefaultMaxLength} symbols!");
            }

            if (user.Password != null && user.Password.Contains(' '))
            {
                errors.Add($"The provided password can't contain whitespaces!");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add("The two passwords don't match!");
            }

            if (user.UserType != UserTypeClient && user.UserType != UserTypeMechanic)
            {
                errors.Add($"The user can be either {UserTypeClient} or {UserTypeMechanic}!");
            }

            return errors;
        }
    }
}
