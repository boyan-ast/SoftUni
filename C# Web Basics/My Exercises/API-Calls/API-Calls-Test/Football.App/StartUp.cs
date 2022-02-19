using Microsoft.EntityFrameworkCore;
using Football.App.Data;
using Football.App.Services;

var data = new ApplicationDbContext();
data.Database.Migrate();

//var importer = new Importer(new AdminService(dbContext));
//await importer.ImportGameweeks();

var adminService = new AdminService(data);
var fixtureService = new FixtureService(adminService, data);
var playerService = new PlayerService(adminService, data);

//await fixtureService.ImportFixtures(17, 2021);
//await playerService.ImportLineups(17);
//await playerService.ImportEvents(17);

var playersGameweekOne = data
    .PlayersGameweeks
    .Where(pg => pg.GameweekId == 17 && pg.Player.TeamId == 2)
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
    .ToList();

foreach (var player in playersGameweekOne)
{
    Console.WriteLine(player);
}
