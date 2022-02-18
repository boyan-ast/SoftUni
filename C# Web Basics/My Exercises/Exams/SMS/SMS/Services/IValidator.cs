using System.Collections.Generic;
using SMS.Models.Products;
using SMS.Models.Users;

namespace SMS.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormModel model);

        ICollection<string> ValidateProduct(CreateProductFormModel model);
    }
}
