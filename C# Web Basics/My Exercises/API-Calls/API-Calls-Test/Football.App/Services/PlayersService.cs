using Football.App.Data;
using Football.App.Data.Models;
using Football.App.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Football.App.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly ApplicationDbContext data;

        public PlayersService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task CalculatePoints(int gameweekId)
        {
            var playersInGameweek = await this.data
                .PlayersGameweeks
                .Include(pg => pg.Player)
                .Where(pg => pg.GameweekId == gameweekId)
                .ToListAsync();

            foreach (var player in playersInGameweek)
            {
                if (player.MinutesPlayed > 0)
                {
                    CalculatePlayerPoints(player);
                }
            }

            await this.data.SaveChangesAsync();
        }

        private void CalculatePlayerPoints(PlayerGameweek player)
        {
            var playerPosition = player.Player.Position;

            var minutesPlayedPoints = CalculateMinutesPlayedPoints(player.MinutesPlayed);
            var cleanSheetPoints = CalculateCleanSheetPoints(playerPosition, player.CleanSheet);
            var goalsPoints = CalculateGoalsPoints(playerPosition, player.Goals);
            var savedPenaltiesPoints = CalculateSavedPenaltiesPoints(playerPosition, player.SavedPenalties);

            var concededGoalsPoints = CalculateConcededGoalsPoints(playerPosition, player.ConcededGoals);
            var yellowCardsPoints = player.YellowCards * 2;
            var redCardPoints = player.RedCards > 0 ? 4 : 0;
            var missedPenaltyPoints = player.MissedPenalties * 6;
            var ownGoalsPoints = player.OwnGoals * 3;

            var bonusPoints = 0;

            var totalPoints = (minutesPlayedPoints + cleanSheetPoints + goalsPoints + savedPenaltiesPoints + bonusPoints) -
                (concededGoalsPoints + yellowCardsPoints + redCardPoints + missedPenaltyPoints + ownGoalsPoints);

            player.TotalPoints = totalPoints;
        }

        private int CalculateConcededGoalsPoints(Position playerPosition, int concededGoals)
        {
            var points = 0;
            var factor = concededGoals / 2;

            if ((playerPosition == Position.Goalkeeper || playerPosition == Position.Defender)
                && concededGoals >= 2)
            {
                points = factor * 2;
            }
            else if (playerPosition == Position.Midfielder && concededGoals >= 2)
            {
                points = factor * 1;
            }

            return points;
        }

        private int CalculateSavedPenaltiesPoints(Position playerPosition, int savedPenalties)
        {
            var points = 0;

            if (playerPosition == Position.Goalkeeper)
            {
                points = savedPenalties * 6;
            }

            return points;
        }

        private int CalculateGoalsPoints(Position playerPosition, int goals)
        {
            var points = 0;

            if (playerPosition == Position.Goalkeeper)
            {
                points = goals * 9;
            }
            else if (playerPosition == Position.Defender)
            {
                points = goals * 7;
            }
            else if (playerPosition == Position.Midfielder)
            {
                points = goals * 6;
            }
            else if (playerPosition == Position.Attacker)
            {
                points = goals * 5;
            }

            return points;
        }

        private int CalculateCleanSheetPoints(Position playerPosition, bool cleanSheet)
        {
            var points = 0;

            if (cleanSheet && (playerPosition == Position.Defender || playerPosition == Position.Goalkeeper))
            {
                points = 5;
            }
            else if (cleanSheet && playerPosition == Position.Midfielder)
            {
                points = 2;
            }

            return points;
        }

        private int CalculateMinutesPlayedPoints(int minutesPlayed)
        {
            var points = 0;

            if (minutesPlayed <= 45)
            {
                points = 1;
            }
            else if (minutesPlayed <= 60)
            {
                points = 2;
            }
            else
            {
                points = 4;
            }

            return points;
        }
    }
}
