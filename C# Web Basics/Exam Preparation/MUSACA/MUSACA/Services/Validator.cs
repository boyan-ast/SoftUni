using System.Collections.Generic;
using System.Text.RegularExpressions;
using MUSACA.ViewModels.Products;
using MUSACA.ViewModels.Users;

using static MUSACA.Data.DataConstants;

namespace MUSACA.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateProduct(CreateProductFormModel model)
        {
            var errors = new List<string>();

            if (model.Name == null || model.Name.Length < ProductNameMinLength || model.Name.Length > DefaultMaxLength)
            {
                errors.Add($"Product name must be between {ProductNameMinLength} and {DefaultMaxLength} characters long!");
            }

            if (model.Price < ProductMinPrice || model.Price > ProductMaxPrice)
            {
                errors.Add($"Product price must be between {ProductMinPrice} and {ProductMaxPrice}");
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
    }
}

