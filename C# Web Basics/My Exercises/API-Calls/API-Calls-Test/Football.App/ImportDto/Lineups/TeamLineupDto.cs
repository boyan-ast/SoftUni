using Newtonsoft.Json;

namespace Football.App.ImportDto.Lineups
{
    public class TeamLineupDto
    {
        public FixtureTeamInfoDto Team { get; set; }

        [JsonProperty("startXI")]
        public LineupPlayerDto[] StartXI { get; set; }

        [JsonProperty("substitutes")]
        public LineupPlayerDto[] Substitutes { get; set; }
    }
}