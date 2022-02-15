using System.Collections.Generic;

namespace MUSACA.ViewModels.Home
{
    public class HomePageViewModel
    {
        public string Username { get; init; }

        public string Role { get; init; }

        public List<OrderListingViewModel> Orders { get; set; }

        public string TotalSum { get; set; }
    }
}
