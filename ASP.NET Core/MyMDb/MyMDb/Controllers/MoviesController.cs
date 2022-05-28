namespace MyMDb.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyMDb.Models.Movie;
    using MyMDb.Services.Movies;

    public class MoviesController : Controller
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [Authorize]
        public IActionResult Add()
        {
            var formModel = new MovieFormModel
            {
                Genres = this.moviesService.GetMoviesGenres()
            };

            return View(formModel);
        }
    }
}
