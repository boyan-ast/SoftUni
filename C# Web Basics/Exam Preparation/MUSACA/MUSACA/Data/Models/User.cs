using System;
using System.ComponentModel.DataAnnotations;
using MUSACA.Data.Models.Enums;

using static MUSACA.Data.DataConstants;

namespace MUSACA.Data.Models
{
    public class User
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public Role Role { get; set; }
    }
}
