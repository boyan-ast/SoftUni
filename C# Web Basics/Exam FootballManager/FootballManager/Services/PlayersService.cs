using System.Linq;
using System.Collections.Generic;

using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.ViewModels.Players;

namespace FootballManager.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly FootballManagerDbContext data;

        public PlayersService(FootballManagerDbContext data)
            => this.data = data;

        public void AddPlayer(
            string creatorId,
            string fullName,
            string imageUrl,
            string position,
            byte speed,
            byte endurance,
            string description)
        {
            var player = new Player
            {
                FullName = fullName,
                ImageUrl = imageUrl,
                Position = position,
                Speed = speed,
                Endurance = endurance,
                Description = description
            };

            var creator = this.data.Users.Find(creatorId);

            creator.UserPlayers.Add(new UserPlayer
            {
                Player = player
            });

            this.data.Players.Add(player);
            this.data.SaveChanges();
        }

        public bool AddPlayerToUserCollection(string userId, int playerId)
        {
            var userPlayersIds = this.data
                .UserPlayers
                .Where(up => up.UserId == userId)
                .Select(up => up.PlayerId)
                .ToList();

            if (userPlayersIds.Contains(playerId))
            {
                return false;
            }

            var user = this.data.Users.Find(userId);

            user.UserPlayers
                .Add(new UserPlayer
                {
                    PlayerId = playerId
                });

            this.data.SaveChanges();

            return true;
        }

        public List<PlayerListingViewModel> GetAll()
            => this.data.Players
                .Select(p => new PlayerListingViewModel
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                    Description = p.Description
                })
                .ToList();

        public List<PlayerListingViewModel> GetUserCollection(string userId)
            => this.data.UserPlayers
                .Where(up => up.UserId == userId)
                .Select(up => up.Player)
                .Select(p => new PlayerListingViewModel
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                    Description = p.Description
                })
                .ToList();

        public bool RemovePlayerFromCollection(string userId, int playerId)
        {
            var userPlayer = this.data
                .UserPlayers
                .Where(up => up.UserId == userId && up.PlayerId == playerId)
                .FirstOrDefault();

            if (userPlayer == null)
            {
                return false;
            }

            this.data.UserPlayers.Remove(userPlayer);
            this.data.SaveChanges();

            return true;
        }
    }
}
