using MyMDb.Services.Movies.Models;
using System.Collections.Generic;

namespace MyMDb.Services.Movies
{
    public interface IMoviesService
    {
        int Create(
            string title,
            int year,
            string imageUrl,
            int genreId,
            string description,
            string creatorId);

        IEnumerable<MovieServiceModel> GetAll();

        IEnumerable<MovieGenreServiceModel> GetMoviesGenres();

        bool GenreExists(int id);
    }
}
