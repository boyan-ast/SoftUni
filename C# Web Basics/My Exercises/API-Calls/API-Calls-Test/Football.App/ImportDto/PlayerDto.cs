using Newtonsoft.Json;

namespace Football.App.ImportDto
{
    public class PlayerDto
    {
        [JsonProperty("id")]
        public int PlayerId { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        [JsonProperty("pos")]
        public string Position { get; set; }
    }
}