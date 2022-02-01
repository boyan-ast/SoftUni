using Football.App.ImportDto;
using Football.App.ImportDto.Event;

namespace Football.App.Services
{
    public interface IAdminServices
    {
        public Task<string[]> GetAllRounds(int league, int season);

        public Task<IEnumerable<FixtureInfoDto>> GetAllFixturesPerRound(string round, int year);

        public Task<IEnumerable<TeamLineupDto>> GetLineups(int fixtureId);

        public Task<IEnumerable<EventResponseDto>> GetFixtureEvents(int fixtureId);

        public Task<IEnumerable<int>> GetFixturesIds(string round);
    }
}
