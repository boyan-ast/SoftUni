namespace MyMDb.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyMDb.Models.Movie;
    using MyMDb.Services.Movies;
    using System.Security.Claims;

    using static MyMDb.Data.DataConstants.Admin;

    public class MoviesController : Controller
    {
        private readonly IMoviesService moviesService;
        private readonly IMapper mapper;

        public MoviesController(
            IMoviesService moviesService,
            IMapper mapper)
        {
            this.moviesService = moviesService;
            this.mapper = mapper;
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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var movies = this.moviesService.GetAll(userId);

            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movieDetails = this.moviesService.GetMovieDetails(id);

            if (movieDetails == null)
            {
                return BadRequest();
            }

            return this.View(movieDetails);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var movie = this.moviesService.GetMovieToEdit(id);

            if (movie.CreatorId != userId && !this.User.IsInRole(AdministratorRoleName))
            {
                return Unauthorized();
            }

            var movieFormModel = this.mapper.Map<MovieFormModel>(movie);
            movieFormModel.Genres = this.moviesService.GetMoviesGenres();

            return this.View(movieFormModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, MovieFormModel movieModel)
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

            this.moviesService.Edit(
                id,
                movieModel.Title,
                movieModel.Year,
                movieModel.ImageUrl,
                movieModel.Description,
                movieModel.GenreId);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id)
        {
            return this.View();
        }
    }
}
