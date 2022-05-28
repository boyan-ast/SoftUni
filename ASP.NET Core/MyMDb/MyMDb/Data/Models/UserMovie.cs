namespace MyMDb.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserMovie
    {
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
