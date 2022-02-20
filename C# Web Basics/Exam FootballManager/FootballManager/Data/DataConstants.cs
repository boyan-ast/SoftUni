namespace FootballManager.Data
{
    public class DataConstants
    {
        public const int DefaultMinLength = 5;
        public const int DefaultMaxLength = 20;
        public const int IdMaxLength = 40;

        public const int EmailMinLength = 10;
        public const int EmailMaxLength = 60;
        public const string EmailRegexPattern = 
            @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int PlayerNameMaxLength = 80;
        public const string PlayerGoalkeeper = "Goalkeeper";
        public const string PlayerRightFullback = "Right Fullback";
        public const string PlayerLeftFullback = "Left Fullback";
        public const string PlayerCenterBack = "Center Back";
        public const string PlayerDefender = "Defender";
        public const string PlayerStriker = "Striker";
        public const string PlayerWinger = "Winger";

        public const byte DefaultMinValue = 0;
        public const byte DefaultMaxValue = 10;
        public const int DescriptionMaxLength = 200;
    }
}
