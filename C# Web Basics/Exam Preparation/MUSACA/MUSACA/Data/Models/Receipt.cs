using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MUSACA.Data.Models
{
    public class Receipt
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime IssuedOn { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        [ForeignKey(nameof(Cashier))]
        public string CashierId { get; set; }

        public User Cashier { get; set; }
    }
}
