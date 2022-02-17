namespace Football.App.Services
{
    public interface IPlayerService
    {
        public Task ImportLineups(int gameweek);
    }
}
