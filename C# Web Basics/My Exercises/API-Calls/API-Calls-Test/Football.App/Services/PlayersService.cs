using Football.App.Data;
using Football.App.Data.Models;
using Football.App.Data.Models.Enums;

using Microsoft.EntityFrameworkCore;

using static Football.App.Services.Common.PlayerPointsConstants;

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
            var savedPenaltiesPoints = CalculateSavedPenaltiesPoints(player.SavedPenalties);

            var concededGoalsPoints = CalculateConcededGoalsPoints(playerPosition, player.ConcededGoals);
            var yellowCardsPoints = player.YellowCards * YellowCardPoints;
            var redCardPoints = player.RedCards > 0 ? RedCardPoints : 0;
            var missedPenaltyPoints = player.MissedPenalties * MissedPenaltyPoints;
            var ownGoalsPoints = player.OwnGoals * OwnGoalPoints;

            var bonusPoints = CalculateBonusPoints(player);

            var totalPoints = (minutesPlayedPoints + cleanSheetPoints + goalsPoints + savedPenaltiesPoints + bonusPoints) -
                (concededGoalsPoints + yellowCardsPoints + redCardPoints + missedPenaltyPoints + ownGoalsPoints) + bonusPoints;

            player.TotalPoints = totalPoints;
        }

        private int CalculateBonusPoints(PlayerGameweek player)
        {
            var points = 0;

            if (player.MinutesPlayed >= 15 && player.TeamResult == TeamResult.Won)
            {
                points += TeamWonBonusPoints;
            }

            if (player.MinutesPlayed > 0 && player.Goals > 1)
            {
                points += GoalsBonusPoints;
            }

            if (player.MinutesPlayed > 0 && player.SavedPenalties > 1)
            {
                points += SavedPenaltiesBonusPoints;
            }

            return points;
        }

        private int CalculateConcededGoalsPoints(Position playerPosition, int concededGoals)
        {
            var points = 0;

            if ((playerPosition == Position.Goalkeeper || playerPosition == Position.Defender)
                && concededGoals >= ConcededGoalsLimit)
            {
                points = concededGoals * ConcededGoalsDefaultPoints;
            }
            else if (playerPosition == Position.Midfielder && concededGoals >= ConcededGoalsLimit)
            {
                points = concededGoals * ConcededGoalsMidfielderPoints;
            }

            return points;
        }

        private int CalculateSavedPenaltiesPoints(int savedPenalties)
        {
            int points = savedPenalties * SavedPenaltyPoints;

            return points;
        }

        private int CalculateGoalsPoints(Position playerPosition, int goals)
        {
            var points = 0;

            if (playerPosition == Position.Goalkeeper)
            {
                points = goals * GoalPointsGoalkeeper;
            }
            else if (playerPosition == Position.Defender)
            {
                points = goals * GoalPointsDefender;
            }
            else if (playerPosition == Position.Midfielder)
            {
                points = goals * GoalPointsMidfielder;
            }
            else if (playerPosition == Position.Attacker)
            {
                points = goals * GoalPointsAttacker;
            }

            return points;
        }

        private int CalculateCleanSheetPoints(Position playerPosition, bool cleanSheet)
        {
            var points = 0;

            if (cleanSheet && (playerPosition == Position.Defender || playerPosition == Position.Goalkeeper))
            {
                points = CleanSheetDefaultPoints;
            }
            else if (cleanSheet && playerPosition == Position.Midfielder)
            {
                points = CleanSheetMidfielderPoints;
            }

            return points;
        }

        private int CalculateMinutesPlayedPoints(int minutesPlayed)
        {
            int points;

            if (minutesPlayed <= AnyMinutesPlayedLimit)
            {
                points = AnyMinutesPlayedPoints;
            }
            else if (minutesPlayed <= MediumMinutesPlayedLimit)
            {
                points = MediumMinutesPlayedPoints;
            }
            else
            {
                points = MaximumMinutesPlayedPoints;
            }

            return points;
        }
    }
}
