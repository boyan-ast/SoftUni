using SMS.ViewModels.Products;

namespace SMS.ViewModels.Users
{
    public class HomePageViewModel
    {
        public string Username { get; init; }

        public ProductListingViewModel[] Products { get; init; }
    }
}
