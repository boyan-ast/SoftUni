using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrickHat.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }

        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
