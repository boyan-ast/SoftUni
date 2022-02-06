using System.Collections.Generic;

namespace CarShop.ViewModels.Issues
{
    public class CarIssueViewModel
    {
        public string Id { get; init; }

        public int Year { get; init; }

        public string Model { get; init; }

        public ICollection<IssueViewModel> Issues { get; init; }
    }
}
