namespace Football.App.Services
{
    public interface IImporter
    {
        public Task ImportTeams();

        public Task ImportStadiums();

        public Task ImportPlayers();

        public Task ImportGameweeks();
    }
}
