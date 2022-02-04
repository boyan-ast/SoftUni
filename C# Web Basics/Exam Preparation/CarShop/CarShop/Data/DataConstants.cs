namespace CarShop.Data
{
    public class DataConstants
    {
        public const int DefaultMaxLength = 20;

        public const int UsernameMinLength = 4;
        public const int PasswordMinLength = 5;
        public const string EmailPattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string UserTypeClient = "Client";
        public const string UserTypeMechanic = "Mechanic";

        public const int ModelMinLength = 5;
        public const int PlateNumberMaxLength = 8;
        public const string PlateNumberPattern = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";

        public const int IssueDescriptionMinLength = 5;
    }
}
