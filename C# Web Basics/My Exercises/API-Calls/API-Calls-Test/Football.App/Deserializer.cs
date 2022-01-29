using Football.App.APICalls;
using Football.App.ImportDto;
using Newtonsoft.Json;
using System.Text;

namespace Football.App
{
    public class Deserializer
    {
        public async Task<string> DeserilizeFixture(int fixtureId)
        {
            StringBuilder sb = new StringBuilder();

            //await Getter.GetFixtureJson(fixtureId);

            var fixtureJson = await File.ReadAllTextAsync("./Datasets/Rounds/1/fixture.json");

            var fixtureInfo = JsonConvert.DeserializeObject<ApiEventResponseDto>(fixtureJson);

            foreach (var matchEvent in fixtureInfo.Response)
            {
                sb.AppendLine((matchEvent.Time.Elapsed + matchEvent.Time.Extra).ToString());
                sb.AppendLine(matchEvent.Type);
                sb.AppendLine(matchEvent.Detail);
                sb.AppendLine(matchEvent.Team.Name);
                sb.AppendLine(matchEvent.Player.Name);
                sb.AppendLine(matchEvent.Assist.Name ?? "No assist");
                sb.Append(new string('-', 10));
            }

            return sb.ToString().TrimEnd();
        }

        public async Task<string> DeserializeRounds(int league, int season)
        {
            StringBuilder sb = new StringBuilder();

            await Getter.GetRoundsJson(league, season);

            var roundsJson = await File.ReadAllTextAsync("rounds.json");

            var roundsResponse = JsonConvert.DeserializeObject<ApiRoundsResponseDto>(roundsJson);

            foreach (var round in roundsResponse.Rounds)
            {
                sb.AppendLine(round);
            }

            return sb.ToString().TrimEnd();
        }

    }
}
