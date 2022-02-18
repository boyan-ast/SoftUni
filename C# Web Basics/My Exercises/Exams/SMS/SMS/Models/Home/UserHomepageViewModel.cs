using SMS.Models.Products;
using System.Collections.Generic;

namespace SMS.Models.Home
{
    public class UserHomepageViewModel
    {
        public string Username { get; init; }

        public List<ProductListingViewModel> Products { get; init; }
    }
}
