using System.Text;
using Football.App.Data;
using Football.App.Services;
using Microsoft.EntityFrameworkCore;

var dbContext = new ApplicationDbContext();
dbContext.Database.Migrate();

var adminService = new AdminService(dbContext);
await adminService.SetTeamsTopPlayers();

//var importer = new Importer(new AdminService(dbContext), new ApplicationDbContext());
//await importer.ImportPlayers();

var teams = dbContext
    .Teams
    .Include(t => t.Players)
    .ToList();

foreach (var team in teams)
{
    Console.WriteLine(team.Name);

    Console.WriteLine($"Top Player: {team.TopPlayer.Name}");

    foreach (var player in team.Players.OrderBy(p => p.Number))
    {
        Console.WriteLine($"{player.Number}. {player.Name} {player.Position}");
    }

    Console.WriteLine(new string('*', 10));
}

static async Task GetFixtureInfo(ApplicationDbContext data)
{
    var deserializer = new AdminService(data);
    var sb = new StringBuilder();

    var allRounds = await deserializer.GetAllRoundsAsync(172, 2021);

    sb.AppendLine(allRounds[0]);
    sb.AppendLine(new string('*', 10));

    var fixturesFirstRound = await deserializer.GetAllFixturesByRoundAsync(allRounds[0]);

    foreach (var fixture in fixturesFirstRound)
    {
        int fixtureId = fixture.Fixture.Id;

        int homeTeamId = fixture.Teams.HomeTeam.Id;
        int awayTeamId = fixture.Teams.AwayTeam.Id;

        sb.AppendLine($"Home team: {fixture.Teams.HomeTeam.Name}");

        var lineupsResult = await deserializer.GetLineupsAsync(fixtureId);

        var lineups = lineupsResult.ToArray();

        var homeTeamLineup = lineups[0];
        var awayTeamLineup = lineups[1];

        sb.AppendLine($"Home team (confirm): {homeTeamLineup.Team.Name}");

        foreach (var lineupPlayer in homeTeamLineup.StartXI)
        {
            sb.AppendLine($"PlayerId: {lineupPlayer.Player.PlayerId}, Number: {lineupPlayer.Player.Number}, " +
                $"Name: {lineupPlayer.Player.Name}, Position: {lineupPlayer.Player.Position}");
        }

        sb.AppendLine($"Away team: {fixture.Teams.AwayTeam.Name}");
        sb.AppendLine($"Home team (confirm): {awayTeamLineup.Team.Name}");

        foreach (var lineupPlayer in awayTeamLineup.StartXI)
        {
            sb.AppendLine($"PlayerId: {lineupPlayer.Player.PlayerId}, Number: {lineupPlayer.Player.Number}, " +
                $"Name: {lineupPlayer.Player.Name}, Position: {lineupPlayer.Player.Position}");
        }

        sb.AppendLine();
        sb.AppendLine();


        var fixtureEvents = await deserializer.GetFixtureEventsAsync(fixtureId);

        foreach (var matchEvent in fixtureEvents)
        {
            int minute = matchEvent.Time.Elapsed + (int)(matchEvent.Time.Extra != null ? matchEvent.Time.Extra : 0);
            sb.AppendLine(minute.ToString());
            sb.AppendLine(matchEvent.Team.Id + " " + matchEvent.Team.Name);
            sb.AppendLine(matchEvent.Type);
            sb.AppendLine(matchEvent.Detail);
            sb.AppendLine(matchEvent.Player.Id + " " + matchEvent.Player.Name);
            sb.AppendLine(matchEvent.Assist.Id + " " + matchEvent.Assist.Name);
            sb.AppendLine();
        }



        sb.AppendLine(new string('*', 20));
    }


    Console.WriteLine(sb);
}
