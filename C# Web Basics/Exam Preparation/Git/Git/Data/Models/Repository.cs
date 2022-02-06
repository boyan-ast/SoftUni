using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static Git.Data.DataConstants;

namespace Git.Data.Models
{
    public class Repository
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(RepositoryMaxLength)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsPublic { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}
