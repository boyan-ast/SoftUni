namespace Football.App.Services
{
    public interface IGameweekImportService
    {
        public Task ImportFixtures(int gameweek, int season);

        public Task ImportLineups(int gameweekNumber);

        public Task ImportEvents(int gameweekNumber);
    }
}
