namespace MyMDb.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyMDb.Models.Movie;
    using MyMDb.Services.Movies;
    using System.Security.Claims;

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

        [Authorize]
        [HttpPost]
        public IActionResult Add(MovieFormModel movieModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!this.moviesService.GenreExists(movieModel.GenreId))
            {
                this.ModelState.AddModelError(nameof(movieModel.GenreId), "Movie genre does not exist.");
            }

            if (!ModelState.IsValid)
            {
                movieModel.Genres = this.moviesService.GetMoviesGenres();
                return View(movieModel);
            }

            this.moviesService.Create(
                movieModel.Title,
                movieModel.Year,
                movieModel.ImageUrl,
                movieModel.GenreId,
                movieModel.Description,
                userId);

            return RedirectToAction(nameof(All));
        }

        public IActionResult All()
        {
            var movies = this.moviesService.GetAll();

            return View(movies);
        }

        public IActionResult Details(int id)
        {
            return this.View();
        }
    }
}
