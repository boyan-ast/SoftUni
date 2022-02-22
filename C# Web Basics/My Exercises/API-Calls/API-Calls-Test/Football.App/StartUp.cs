using Microsoft.EntityFrameworkCore;
using Football.App.Data;
using Football.App.Services;

var data = new ApplicationDbContext();
data.Database.Migrate();

//var importer = new Importer(new AdminService(dbContext));
//await importer.ImportGameweeks();

var footballDataService = new FootballDataService(data);
var gameweekImportService = new GameweekImportService(footballDataService, data);

//await gameweekImportService.ImportFixtures(14, 2021);
//await gameweekImportService.ImportLineups(14);
//await gameweekImportService.ImportEvents(14);

var playersGameweekOne = data
    .PlayersGameweeks
    .Where(pg => pg.GameweekId == 14 && pg.Player.TeamId == 3)
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
        pg.ConcededGoals
    })
    .OrderByDescending(p => p.MinutesPlayed)
    .ToList();

foreach (var player in playersGameweekOne)
{
    Console.WriteLine(player);
}
