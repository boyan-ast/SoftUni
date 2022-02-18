using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static SMS.Data.DataConstants;

namespace SMS.Data.Models
{
    public class Product
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [ForeignKey(nameof(Cart))]
        public string CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
