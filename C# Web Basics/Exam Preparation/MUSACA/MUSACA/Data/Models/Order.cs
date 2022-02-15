using MUSACA.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MUSACA.Data.Models
{
    public class Order
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public Status Status { get; set; }

        [ForeignKey(nameof(Product))]
        public string ProductId { get; set; }

        public Product Product { get; set; }

        public int? Quantity { get; set; }

        [ForeignKey(nameof(Cashier))]
        public string CashierId { get; set; }

        public User Cashier { get; set; }
    }
}
