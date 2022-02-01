using Newtonsoft.Json;

namespace Football.App.ImportDto
{
    public class FixtureTeamsDto
    {
        [JsonProperty("home")]
        public TeamInfoDto HomeTeam { get; set; }

        [JsonProperty("away")]
        public TeamInfoDto AwayTeam { get; set; }
    }
}
