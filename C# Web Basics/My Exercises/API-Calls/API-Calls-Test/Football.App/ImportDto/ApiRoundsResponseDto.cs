using Newtonsoft.Json;

namespace Football.App.ImportDto
{
    internal class ApiRoundsResponseDto
    {
        public int Results { get; set; }

        [JsonProperty("response")]
        public string[] Rounds { get; set; }
    }
}
