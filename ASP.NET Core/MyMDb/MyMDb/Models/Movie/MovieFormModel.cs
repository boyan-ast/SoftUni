namespace MyMDb.Models.Movie
{
    using MyMDb.Services.Movies.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Movie;

    public class MovieFormModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; init; }

        [Range(YearMinValue, YearMaxValue)]
        public int Year { get; init; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        [Required]
        [StringLength(
            DescriptionMaxLength, 
            MinimumLength = DescriptionMinLength, 
            ErrorMessage ="The {0} must be a string with minumum length of {2} and maximum length of {1}")]
        public string Description { get; init; }

        [Display(Name = "Genre")]
        public int GenreId { get; init; }

        public IEnumerable<MovieGenreServiceModel> Genres { get; set; }
    }
}
