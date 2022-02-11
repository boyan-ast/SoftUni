using Newtonsoft.Json;

namespace Football.App.ImportDto
{
    public class FixtureTeamsDto
    {
        [JsonProperty("home")]
        public FixtureTeamInfoDto HomeTeam { get; set; }

        [JsonProperty("away")]
        public FixtureTeamInfoDto AwayTeam { get; set; }
    }
}
