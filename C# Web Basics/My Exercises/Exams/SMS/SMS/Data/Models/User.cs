using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SMS.Data.DataConstants;

namespace SMS.Data.Models
{
    public class User
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [ForeignKey(nameof(Cart))]
        public string CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
