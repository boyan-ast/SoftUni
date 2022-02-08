using Football.App.ImportDto;
using Football.App.ImportDto.Event;

namespace Football.App.Services
{
    public interface IAdminServices
    {
        public Task<string[]> GetAllRoundsAsync(int league, int season);

        public Task<IEnumerable<FixtureInfoDto>> GetAllFixturesByRoundAsync(string round, int year);

        public Task<IEnumerable<TeamLineupDto>> GetLineupsAsync(int fixtureId);

        public Task<IEnumerable<EventResponseDto>> GetFixtureEventsAsync(int fixtureId);

        public Task<ICollection<int>> GetFixturesIdsAsync(string round);
    }
}
