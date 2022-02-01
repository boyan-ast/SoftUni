using Newtonsoft.Json;

namespace Football.App.ImportDto
{
    public class FixtureStatusDto
    {
        [JsonProperty("short")]
        public string Status { get; set; }

        [JsonProperty("elapsed")]
        public int? MinutesPlayed { get; set; }
    }
}
