namespace SMS.Services
{
    public interface IUsersService
    {
        string CreateUser(string username, string email, string password);

        bool IsEmailAvailable(string email);

        string GetUserId(string username, string password);

        object GetUsername(string userId);

        bool IsUsernameAvailable(string username);
    }
}
