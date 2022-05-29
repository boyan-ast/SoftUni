namespace MyMDb.Services.Movies.Models
{
    public class MovieServiceModel
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public int Year { get; init; }

        public string ImageUrl { get; init; }

        public string Genre { get; init; }

        public bool UserIsCreator { get; init; }
    }
}
