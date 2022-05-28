namespace MyMDb.Services.Movies
{
    using System.Collections.Generic;
    using System.Linq;
    using MyMDb.Data;
    using MyMDb.Services.Movies.Models;

    public class MoviesService : IMoviesService
    {
        private readonly ApplicationDbContext data;

        public MoviesService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public int Create()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MovieGenreServiceModel> GetMoviesGenres()
            => this.data
                .Genres
                .Select(g => new MovieGenreServiceModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToList();
    }
}
