using Newtonsoft.Json;

namespace Football.App.ImportDto.Fixtures
{
    public class ApiFixturesResponseDto
    {
        public int Results { get; set; }

        [JsonProperty("response")]
        public FixtureInfoDto[] FixturesInfo { get; set; }
    }
}
