using System.Linq;

using FootballManager.Services;
using FootballManager.ViewModels.Players;

using MyWebServer.Controllers;
using MyWebServer.Http;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPlayersService playersService;

        public PlayersController(
            IValidator validator,
            IPlayersService playersService)
        {
            this.validator = validator;
            this.playersService = playersService;
        }

        [Authorize]
        public HttpResponse Add()
            => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddPlayerFormModel player)
        {
            var errors = this.validator.ValidatePlayer(player);

            if (errors.Any())
            {
                return Error(errors);
            }

            this.playersService.AddPlayer(
                User.Id,
                player.FullName,
                player.ImageUrl,
                player.Position,
                (byte)player.Speed,
                (byte)player.Endurance,
                player.Description);            

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var players = this.playersService.GetAll();

            return View(players);
        }

        [Authorize]
        public HttpResponse AddToCollection(int playerId)
        {
            var successfullyAdded = this.playersService.AddPlayerToUserCollection(User.Id, playerId);

            if (!successfullyAdded)
            {
                return Error("You already have this player in your collection.");
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var userPlayers = this.playersService.GetUserCollection(User.Id);

            return View(userPlayers);
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int playerId)
        {
            var deletionSucceeded = this.playersService.RemovePlayerFromCollection(User.Id, playerId);

            if (!deletionSucceeded)
            {
                return Error("You don't have this user in your collection.");
            }

            return Redirect("/Players/Collection");
        }
    }
}
