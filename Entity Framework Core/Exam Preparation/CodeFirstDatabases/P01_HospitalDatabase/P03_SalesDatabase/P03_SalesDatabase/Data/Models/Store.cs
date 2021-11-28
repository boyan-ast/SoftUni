using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models
{
    public class Store
    {
        public Store()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int StoreId { get; set; }

        [MaxLength(80)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
