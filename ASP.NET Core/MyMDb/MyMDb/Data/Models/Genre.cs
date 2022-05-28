namespace MyMDb.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Genre;

    public class Genre
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(GenreMaxLength)]
        public string Name { get; init; }

        public IEnumerable<Movie> Movies { get; init; } = new HashSet<Movie>();
    }
}
