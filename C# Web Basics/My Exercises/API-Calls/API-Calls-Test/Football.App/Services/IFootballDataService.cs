using Football.App.ImportDto;
using Football.App.ImportDto.Event;
using Football.App.ImportDto.Fixtures;
using Football.App.ImportDto.Lineups;
using Football.App.ImportDto.Players;
using Football.App.ImportDto.Teams;

namespace Football.App.Services
{
    public interface IFootballDataService
    {
        public Task<string[]> GetAllRoundsAsync(int league, int season);

        public Task<IEnumerable<FixtureInfoDto>> GetAllFixturesByGameweekAsync(int gameweek, int year);

        public Task<IEnumerable<TeamLineupDto>> GetLineupsAsync(int fixtureId);

        public Task<IEnumerable<EventResponseDto>> GetFixtureEventsAsync(int fixtureId);

        public ICollection<int> GetFixturesIds(string round);

        public Task<IEnumerable<TeamStadiumDto>> GetTeamsAndStadiumsJsonAsync(int leagueId, int season);

        public Task<TeamPlayersInfoDto> GetTeamSquadJsonAsync(int teamId);

        public Task SetTeamsTopPlayers();
    }
}
