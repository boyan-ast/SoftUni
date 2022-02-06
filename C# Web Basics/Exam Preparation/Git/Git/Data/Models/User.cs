using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static Git.Data.DataConstants;

namespace Git.Data.Models
{
    public class User
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Repository> Repositories { get; set; } = new HashSet<Repository>();

        public ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}
