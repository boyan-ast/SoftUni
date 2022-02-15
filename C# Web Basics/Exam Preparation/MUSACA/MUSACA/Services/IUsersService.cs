namespace MUSACA.Services
{
    public interface IUsersService
    {
        string CreateUser(string username, string email, string password);

        bool IsEmailAvailable(string email);

        string GetUserId(string username, string password);

        string GetUsername(string userId);

        bool IsUsernameAvailable(string username);
    }
}
