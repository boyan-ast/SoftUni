using Newtonsoft.Json;

namespace Football.App.ImportDto
{
    public class TeamLineupDto
    {
        public FixtureTeamInfoDto Team { get; set; }

        [JsonProperty("startXI")]
        public LineupPlayerDto[] StartXI { get; set; }

        [JsonProperty("substitutes")]
        public TeamLineupDto[] Substitutes { get; set; }
    }
}