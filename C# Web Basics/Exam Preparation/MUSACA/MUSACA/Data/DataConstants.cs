namespace MUSACA.Data
{
    public class DataConstants
    {
        public const int DefaultMaxLength = 20;

        public const int UsernameMinLength = 5;
        public const int PasswordMinLength = 6;
        public const string EmailPattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int ProductNameMinLength = 3;
        public const int BarcodeMaxLength = 20;
        public const string BarcodeRegexPattern = @"^[0-9]{12}$";
        public const decimal ProductMinPrice = 0.05m;
        public const decimal ProductMaxPrice = 1000m;
    }
}
