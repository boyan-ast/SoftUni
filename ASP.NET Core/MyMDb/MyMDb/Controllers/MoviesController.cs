namespace MyMDb.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class MoviesController : Controller
    {
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
    }
}
