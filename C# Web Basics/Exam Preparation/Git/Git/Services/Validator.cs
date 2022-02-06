using Git.ViewModels.Repositories;
using Git.ViewModels.Users;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static Git.Data.DataConstants;

namespace Git.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateRepository(CreateRepositoryFormModel model)
        {
            var errors = new List<string>();

            if (model.Name == null || model.Name.Length < RepositoryMinLength || model.Name.Length > RepositoryMaxLength)
            {
                errors.Add($"Repository name must be between {RepositoryMinLength} and {RepositoryMaxLength} symbols long!");
            }

            if (model.RepositoryType.ToLower() != PublicRepositoryType && model.RepositoryType.ToLower() != PrivateRepositoryType)
            {
                errors.Add($"Repository type must be either '{PublicRepositoryType}' or '{PrivateRepositoryType}'!");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterFormModel model)
        {
            var errors = new List<string>();

            if (model.Username == null || model.Username.Length < UsernameMinLength || model.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username must be between {UsernameMinLength} and {UsernameMaxLength} characters long!");
            }

            if (!Regex.IsMatch(model.Email, EmailPattern))
            {
                errors.Add($"Email {model.Email} is not valid!");
            }

            if (model.Password.Length < PasswordMinLength || model.Password.Length > PasswordMaxLength)
            {
                errors.Add($"Password must be between {PasswordMinLength} and {PasswordMaxLength} characters long!");
            }

            return errors;
        }
    }
}
