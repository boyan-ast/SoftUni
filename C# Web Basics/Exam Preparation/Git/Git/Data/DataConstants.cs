namespace Git.Data
{
    public class DataConstants
    {
        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;
        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 20; // not for the db, it is hashed
        public const string EmailPattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int RepositoryMinLength = 3;
        public const int RepositoryMaxLength = 10;
        public const string PublicRepositoryType = "public";
        public const string PrivateRepositoryType = "private";

        public const int CommitMinLength = 5;
    }
}
