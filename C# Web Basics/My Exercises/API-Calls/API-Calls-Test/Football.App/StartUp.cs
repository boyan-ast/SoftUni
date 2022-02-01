using Football.App.Services;
using System.Text;

var sb = new StringBuilder();

var deserializer = new AdminServices();

var allRounds = await deserializer.GetAllRounds(172, 2021);

sb.AppendLine(allRounds[0]);
sb.AppendLine(new string('*', 10));

var fixturesFirstRound = await deserializer.GetAllFixturesPerRound(allRounds[0]);

foreach (var fixture in fixturesFirstRound)
{
    int fixtureId = fixture.Fixture.Id;
    int homeTeamId = fixture.Teams.HomeTeam.Id;
    int awayTeamId = fixture.Teams.AwayTeam.Id;

    sb.AppendLine($"Home team: {fixture.Teams.HomeTeam.Name}");

    var lineups = await deserializer.GetLineups(fixtureId);

    var homeTeamLineup = lineups.First();
    var awayTeamLineup = lineups.Skip(1).First();

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


    var fixtureEvents = await deserializer.GetFixtureEvents(fixtureId);

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