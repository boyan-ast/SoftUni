using System.Text;
using Football.App.Data;
using Football.App.Services;
using Microsoft.EntityFrameworkCore;

var data = new ApplicationDbContext();
data.Database.Migrate();

//var importer = new Importer(new AdminService(dbContext));
//await importer.ImportGameweeks();

var adminService = new AdminService(data);
var fixtureService = new FixtureService(adminService, data);
var playerService = new PlayerService(adminService, data);

//await fixtureService.ImportFixtures(18, 2021);
//await playerService.ImportLineups(18);
//await playerService.ImportEvents(18);

var playersGameweekOne = data
    .PlayersGameweeks
    .Where(pg => pg.GameweekId == 18 && pg.Player.TeamId == 1)
    .Select(pg => new
    {
        Player = pg.Player.Name,
        PlayerTeam = pg.Player.Team.Name,
        pg.InStartingLineup,
        pg.IsSubstitute,
        pg.MinutesPlayed,
        pg.Goals,

        pg.YellowCards,
        pg.RedCards
    })
    .ToList();

foreach (var player in playersGameweekOne)
{
    Console.WriteLine(player);
}
