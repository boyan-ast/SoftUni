namespace MyMDb.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Movie;

    public class Movie
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public User Creator { get; set; }

        public IEnumerable<UserMovie> MovieUsers { get; init; } = new HashSet<UserMovie>();
    }
}
