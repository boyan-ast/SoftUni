using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorJsonInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{3}-[0-9]{3}-[0-9]{4}")]
        public string Phone { get; set; }

        [Required]
        [Email]
        public string Email { get; set; }

        public AuthorBookJsonInputModel[] Books { get; set; }
    }
}
