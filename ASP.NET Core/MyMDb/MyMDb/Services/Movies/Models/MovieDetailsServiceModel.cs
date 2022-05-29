namespace MyMDb.Services.Movies.Models
{
    public class MovieDetailsServiceModel
    {
        public int Id { get; init; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string ImageUrl { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public string Creator { get; set; }

        public int Likes { get; set; }
    }
}
