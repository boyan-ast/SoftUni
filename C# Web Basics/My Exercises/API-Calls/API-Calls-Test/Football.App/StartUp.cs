using Microsoft.EntityFrameworkCore;
using Football.App.Data;
using Football.App.Services;

var data = new ApplicationDbContext();
data.Database.Migrate();

var footballDataService = new FootballDataService(data);

var initialImportService = new InitialImportService(footballDataService, data);
var gameweekImportService = new GameweekImportService(footballDataService, data);
var playersService = new PlayersService(data);

//await initialImportService.ImportTeams();
//await initialImportService.ImportStadiums();
//await initialImportService.ImportPlayers();
//await initialImportService.ImportGameweeks();
//await footballDataService.SetTeamsTopPlayers();

//await gameweekImportService.ImportFixtures(20, 2021);

await gameweekImportService.ImportLineups(20);
await gameweekImportService.ImportEvents(20);
await playersService.CalculatePoints(20);

var playersGameweekOne = data
    .PlayersGameweeks
    .Where(pg => pg.GameweekId == 20 && pg.Player.TeamId == 3)
    .Select(pg => new
    {
        Player = pg.Player.Name,
        PlayerTeam = pg.Player.Team.Name,
        pg.InStartingLineup,
        pg.IsSubstitute,
        pg.MinutesPlayed,
        pg.Goals,
        pg.YellowCards,
        pg.RedCards,
        pg.CleanSheet,
        pg.ConcededGoals,
        pg.TotalPoints,
        PlayerTeamWon = pg.TeamResult
    })
    .OrderByDescending(p => p.TotalPoints)
    .ToList();

foreach (var player in playersGameweekOne)
{
    Console.WriteLine($"Name : {player.Player}");
    Console.WriteLine($"Minutes played: {player.MinutesPlayed}");
    Console.WriteLine($"Goals: {player.Goals}");
    Console.WriteLine($"Yellow cards: {player.YellowCards}");
    Console.WriteLine($"Red cards: {player.RedCards}");
    Console.WriteLine($"Has clean sheet {player.CleanSheet}");
    Console.WriteLine($"Conceded goals: {player.ConcededGoals}");
    Console.WriteLine($"Total points for gameweek: {player.TotalPoints}");
    Console.WriteLine(new string('*', 10));
    Console.WriteLine($"Player team: {player.PlayerTeam} -> {player.PlayerTeamWon}");
    Console.WriteLine(new string('*', 10));
    Console.WriteLine(new string('*', 10));
}
