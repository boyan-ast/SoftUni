using System;
using System.ComponentModel.DataAnnotations;

using static SMS.Data.DataConstants;

namespace SMS.Data.Models
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

        public string CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
