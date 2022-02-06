namespace Git.Data
{
    public class DataConstants
    {
        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;
        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 20; // not for the db, it is hashed

        public const int RepositoryMinLength = 3;
        public const int RepositoryMaxLength = 10;

        public const int CommitMinLength = 5;
    }
}
