using System.Collections.Generic;

using FootballManager.ViewModels.Players;

namespace FootballManager.Services
{
    public interface IPlayersService
    {
        void AddPlayer(
            string creatorId,
            string fullName, 
            string imageUrl, 
            string position, 
            byte speed, 
            byte endurance, 
            string description);

        List<PlayerListingViewModel> GetAll();

        List<PlayerListingViewModel> GetUserCollection(string userId);

        bool AddPlayerToUserCollection(string userId, int playerId);

        bool RemovePlayerFromCollection(string userId, int playerId);
    }
}
