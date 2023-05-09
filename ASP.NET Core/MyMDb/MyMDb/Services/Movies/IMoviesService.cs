﻿using MyMDb.Services.Movies.Models;
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

        IEnumerable<MovieServiceModel> GetAll(string userId = null);

        IEnumerable<MovieGenreServiceModel> GetMoviesGenres();

        MovieEditServiceModel GetMovieToEdit(int id);

        MovieDetailsServiceModel GetMovieDetails(int id);

        void Edit(
            int id,
            string title,
            int year,
            string imageUrl,
            string description,
            int genreId);

        bool GenreExists(int id);
    }
}