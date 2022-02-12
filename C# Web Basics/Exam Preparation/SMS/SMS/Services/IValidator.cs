using System.Collections.Generic;
using SMS.ViewModels.Products;
using SMS.ViewModels.Users;

namespace SMS.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormModel model);

        ICollection<string> ValidateProduct(CreateProductFormModel model);
    }
}
