using Football.App.Common;
using RestSharp;

namespace Football.App.APICalls
{
    public static class Getter
    {
        private static RestClient client;

        public static async Task GetFixtureJson(int fixtureId)
        {
            var url = $"https://v3.football.api-sports.io/fixtures/events?fixture={fixtureId}";

            var authHeader = new Header("x-apisports-key", Constants.Key);
            var headers = new List<Header>();
            headers.Add(authHeader);

            var response = await GetResponse(url, headers);

            using (var sw = new StreamWriter("fixture.json"))
            {
                await sw.WriteAsync(response.Content);
            }
        }

        public static async Task GetRoundsJson(int league, int season)
        {
            var url = $"https://v3.football.api-sports.io/fixtures/rounds?season={season}&league={league}";

            var authHeader = new Header("x-apisports-key", Constants.Key);
            var headers = new List<Header>();
            headers.Add(authHeader);

            var response = await GetResponse(url, headers);

            using (var sw = new StreamWriter("rounds.json"))
            {
                await sw.WriteAsync(response.Content);
            }
        }

        private static async Task<RestResponse> GetResponse(string url, IEnumerable<Header> headers)
        {
            client = new RestClient(url);
            var request = new RestRequest();

            foreach (var header in headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

            return await client.ExecuteGetAsync(request);
        }
    }
}
