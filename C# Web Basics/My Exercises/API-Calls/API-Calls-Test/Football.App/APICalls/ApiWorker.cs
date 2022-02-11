using Football.App.Common;

namespace Football.App.APICalls
{
    public static class ApiWorker
    {
        public static async Task<string> GetSquadAsync(int teamId)
        {
            var url = $"https://v3.football.api-sports.io/players/squads?team={teamId}";

            string result = await GetResponseAsync(url);

            return result;
        }

        public static async Task<string> GetAllTeamsAsync(int leagueId, int season)
        {
            var url = $"https://v3.football.api-sports.io/teams?league={leagueId}&season={season}";

            string result = await GetResponseAsync(url);

            return result;
        }

        public static async Task<string> GetLineupsJsonAsync(int fixtureId)
        {
            var url = $"https://v3.football.api-sports.io/fixtures/lineups?fixture={fixtureId}";

            string result = await GetResponseAsync(url);

            return result;
        }

        public static async Task<string> GetFixtureEventsJsonAsync(int fixtureId)
        {
            var url = $"https://v3.football.api-sports.io/fixtures/events?fixture={fixtureId}";

            return await GetResponseAsync(url);
        }

        public static async Task<string> GetRoundsJsonAsync(int league, int season)
        {
            var url = $"https://v3.football.api-sports.io/fixtures/rounds?season={season}&league={league}";

            return await GetResponseAsync(url);
        }

        public static async Task<string> GetLeaguesJsonAsync(string countryCode, int season)
        {
            var url = $"https://v3.football.api-sports.io/leagues?code={countryCode}&season={season}";

            return await GetResponseAsync(url);
        }

        public static async Task<string> GetFixturesByRoundAsync(string round, int season)
        {
            var url = $"https://v3.football.api-sports.io/fixtures?season={season}&round={round}&league=172";

            return await GetResponseAsync(url);
        }

        private static async Task<string> GetResponseAsync(string url)
        {
            var apiResponseString = string.Empty;

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("x-apisports-key", Constants.Key);

            using (httpClient)
            {
                var response = await httpClient.GetAsync(url);                
                apiResponseString = await response.Content.ReadAsStringAsync();
            }

            await Task.Delay(8000);

            return apiResponseString;
        }
    }
}
