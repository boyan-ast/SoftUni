namespace MyMDb.Data
{
    public class DataConstants
    {
        public class Movie
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 30;
            public const int YearMinValue = 1900;
            public const int YearMaxValue = 2100;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 500;
        }

        public class Genre
        {
            public const int GenreMaxLength = 20;
        }
    }
}
