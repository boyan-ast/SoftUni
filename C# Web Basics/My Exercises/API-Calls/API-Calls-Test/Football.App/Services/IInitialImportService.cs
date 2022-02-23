namespace Football.App.Services
{
    public interface IInitialImportService
    {
        public Task ImportTeams();

        public Task ImportStadiums();

        public Task ImportPlayers();

        public Task ImportGameweeks();
    }
}
