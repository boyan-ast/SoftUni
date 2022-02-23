namespace Football.App.Services
{
    public interface IPlayersService
    {
        public Task CalculatePoints(int gameweekId);
    }
}
