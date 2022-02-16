namespace Git.Data
{
    public class DataConstants
    {
        public const int DefaultMaxLength = 20;

        public const int UsernameMinLength = 5;
        public const int PasswordMinLength = 6;
        public const string EmailPattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int RepositoryNameMinLength = 3;
        public const int RepositoryNameMaxLength = 10;
        public const string RepositoryTypePublic = "Public";
        public const string RepositoryTypePrivate = "Private";

        public const int CommitMinLength = 5;

        public const string DateTimeFormat = "dd.MM.yyyy HH:mm";
    }
}
