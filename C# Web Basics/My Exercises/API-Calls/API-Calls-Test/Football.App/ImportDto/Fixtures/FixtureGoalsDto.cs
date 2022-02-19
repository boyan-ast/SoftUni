using Newtonsoft.Json;

namespace Football.App.ImportDto.Fixtures
{
    public class FixtureGoalsDto
    {
        [JsonProperty("home")]
        public int HomeGoals { get; init; }

        [JsonProperty("away")]
        public int AwayGoals { get; init; }
    }
}