using System.Collections.Generic;
using System.Text.RegularExpressions;
using SMS.Models.Products;
using SMS.Models.Users;

using static SMS.Data.DataConstants;

namespace SMS.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateProduct(CreateProductFormModel model)
        {
            var errors = new List<string>();

            if (model.Name == null || model.Name.Length < ProductNameMinLength || model.Name.Length > DefaultMaxLength)
            {
                errors.Add("Invalid product name.");
            }

            if (model.Price < ProductMinPrice || model.Price > ProductMaxPrice)
            {
                errors.Add($"Price must be between {ProductMinPrice} and {ProductMaxPrice}.");
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

