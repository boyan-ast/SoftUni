using System;
using System.ComponentModel.DataAnnotations;

using static MUSACA.Data.DataConstants;

namespace MUSACA.Data.Models
{
    public class Product
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
