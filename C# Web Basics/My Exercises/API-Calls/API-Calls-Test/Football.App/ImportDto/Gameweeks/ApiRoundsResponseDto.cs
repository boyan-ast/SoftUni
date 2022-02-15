using Newtonsoft.Json;

namespace Football.App.ImportDto.Gameweeks
{
    public class ApiRoundsResponseDto
    {
        public int Results { get; set; }

        [JsonProperty("response")]
        public string[] Rounds { get; set; }
    }
}
