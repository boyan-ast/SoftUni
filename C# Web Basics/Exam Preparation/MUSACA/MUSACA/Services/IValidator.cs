using System.Collections.Generic;
using MUSACA.ViewModels.Products;
using MUSACA.ViewModels.Users;

namespace MUSACA.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormModel model);

        ICollection<string> ValidateProduct(CreateProductFormModel model);

    }
}
