namespace Football.App.Services
{
    public interface IPlayerService
    {
        public Task InitialImportPlayersGameweeks(int gameweek);
    }
}
