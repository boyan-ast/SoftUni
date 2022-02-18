using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static SMS.Data.DataConstants;

namespace SMS.Data.Models
{
    public class Cart
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public User User { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
