namespace Football.App.Services
{
    public interface ISeasonStartService
    {
        public Task ImportTeams();

        public Task ImportStadiums();

        public Task ImportPlayers();

        public Task ImportGameweeks();
    }
}
