using RestSharp;

using Football.App;
using Football.App.Common;
using Football.App.ImportDto;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

string fixtureId = "770994";

var fixtureJson = await File.ReadAllTextAsync("fixture.json");

JObject jObject = JObject.Parse(fixtureJson);

var response = jObject["response"].Children().ToList();

List<EventInputDto> matchEvents = new List<EventInputDto>();

foreach (JToken result in response)
{
    EventInputDto matchEvent = result.ToObject<EventInputDto>();
    matchEvents.Add(matchEvent);
}

//var fixureEvents = JsonConvert.DeserializeObject<EventInputDto[]>(responseObjText);

Console.ReadLine();

static async Task GetFixtureJson(string fixtureId)
{
    var baseUrl = $"https://v3.football.api-sports.io/fixtures/events?fixture={fixtureId}";
    var client = new RestClient(baseUrl);
    var request = new RestRequest();

    var authHeader = new Header("x-apisports-key", Constants.Key);

    request.AddHeader(authHeader.Key, authHeader.Value);

    var response = await client.ExecuteGetAsync(request);

    using (var sw = new StreamWriter("fixture"))
    {
        await sw.WriteAsync(response.Content);
    }
}