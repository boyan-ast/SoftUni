namespace MyMDb.Services.Movies
{
    using System.Collections.Generic;
    using System.Linq;
    using MyMDb.Data;
    using MyMDb.Data.Models;
    using MyMDb.Services.Movies.Models;

    public class MoviesService : IMoviesService
    {
        private readonly ApplicationDbContext data;

        public MoviesService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public int Create(
            string title,
            int year,
            string imageUrl,
            int genreId,
            string description,
            string creatorId)
        {
            var movieData = new Movie
            {
                Title = title,
                Year = year,
                ImageUrl = imageUrl,
                GenreId = genreId,
                Description = description,
                CreatorId = creatorId
            };

            this.data.Movies.Add(movieData);

            this.data.SaveChanges();

            return movieData.Id;
        }

        public IEnumerable<MovieServiceModel> GetAll(string userId = null)
            => this.data
                .Movies
                .Select(m => new MovieServiceModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year,
                    ImageUrl = m.ImageUrl,
                    Genre = m.Genre.Name,
                    UserIsCreator = m.CreatorId == userId
                })
                .ToList();

        public bool GenreExists(int id)
            => this.data
                .Genres
                .Any(g => g.Id == id);

        public IEnumerable<MovieGenreServiceModel> GetMoviesGenres()
            => this.data
                .Genres
                .Select(g => new MovieGenreServiceModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToList();

        public MovieDetailsServiceModel GetMovieDetails(int id)
            => this.data
                .Movies
                .Where(m => m.Id == id)
                .Select(m => new MovieDetailsServiceModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year,
                    ImageUrl = m.ImageUrl,
                    Genre = m.Genre.Name,
                    Description = m.Description,
                    Creator = m.Creator.UserName,
                    Likes = m.MovieUsers.Count()
                })
                .FirstOrDefault();
    }
}
