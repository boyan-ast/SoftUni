using MyMDb.Services.Movies.Models;
using System.Collections.Generic;

namespace MyMDb.Services.Movies
{
    public interface IMoviesService
    {
        int Create();

        IEnumerable<MovieGenreServiceModel> GetMoviesGenres();
    }
}
