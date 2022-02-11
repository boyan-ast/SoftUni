using Football.App.ImportDto;
using Football.App.ImportDto.Event;
using Football.App.ImportDto.Players;
using Football.App.ImportDto.Teams;

namespace Football.App.Services
{
    public interface IAdminServices
    {
        public Task<string[]> GetAllRoundsAsync(int league, int season);

        public Task<IEnumerable<FixtureInfoDto>> GetAllFixturesByRoundAsync(string round, int year);

        public Task<IEnumerable<TeamLineupDto>> GetLineupsAsync(int fixtureId);

        public Task<IEnumerable<EventResponseDto>> GetFixtureEventsAsync(int fixtureId);

        public ICollection<int> GetFixturesIds(string round);

        public Task<IEnumerable<TeamStadiumDto>> GetTeamsAndStadiumsJsonAsync(int leagueId, int season);

        public Task<TeamPlayersInfoDto> GetTeamSquadJsonAsync(int teamId);
    }
}
