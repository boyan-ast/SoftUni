namespace Football.App.Services
{
    public interface IFixtureService
    {
        public Task ImportFixtures(int gameweek, int season);
    }
}
