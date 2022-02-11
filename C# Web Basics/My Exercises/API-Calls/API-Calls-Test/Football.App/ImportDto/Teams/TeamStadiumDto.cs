using Newtonsoft.Json;

namespace Football.App.ImportDto.Teams
{
    public class TeamStadiumDto
    {
        public TeamInfoDto Team { get; set; }

        [JsonProperty("venue")]
        public StadiumInfoDto Stadium { get; set; }
    }
}
