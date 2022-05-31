namespace MyMDb.Services.Movies.Models
{
    public class MovieEditServiceModel
    {
        public string Title { get; init; }

        public int Year { get; init; }

        public string ImageUrl { get; init; }

        public string Description { get; init; }

        public int GenreId { get; init; }

        public string CreatorId { get; init; }
    }
}
