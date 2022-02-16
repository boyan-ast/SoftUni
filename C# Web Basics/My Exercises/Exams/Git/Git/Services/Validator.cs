using System.Collections.Generic;
using System.Text.RegularExpressions;
using Git.Models.Commits;
using Git.Models.Repositories;
using Git.Models.Users;

using static Git.Data.DataConstants;

namespace Git.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateCommit(CreateCommitFormModel model)
        {
            var errors = new List<string>();

            if (model.Id == null)
            {
                errors.Add("No repository id provided,");
            }

            if (model.Description == null || model.Description.Length < CommitMinLength)
            {
                errors.Add($"Commit description must be at least {CommitMinLength} characters long.");
            }

            return errors;
        }

        public ICollection<string> ValidateRepository(CreateRepositoryFormModel model)
        {
            var errors = new List<string>();

            if (model.Name == null || model.Name.Length < RepositoryNameMinLength || model.Name.Length > RepositoryNameMaxLength)
            {
                errors.Add($"Repository name '{model.Name}' is not valid. It must be between {RepositoryNameMinLength} and {RepositoryNameMaxLength} characters long.");
            }

            if (model.RepositoryType != RepositoryTypePrivate && model.RepositoryType != RepositoryTypePublic)
            {
                errors.Add($"Repository Type must be either {RepositoryTypePrivate} or {RepositoryTypePublic}.");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterFormModel model)
        {
            var errors = new List<string>();

            if (model.Username == null || model.Username.Length < UsernameMinLength || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username must be between {UsernameMinLength} and {DefaultMaxLength} characters long.");
            }

            if (model.Email == null || !Regex.IsMatch(model.Email, EmailPattern))
            {
                errors.Add($"Email {model.Email} is not valid.");
            }

            if (model.Password == null || model.Password.Length < PasswordMinLength || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"Password must be between {PasswordMinLength} and {DefaultMaxLength} characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and Confirm Password are not the same.");
            }

            return errors;
        }       
    }
}

