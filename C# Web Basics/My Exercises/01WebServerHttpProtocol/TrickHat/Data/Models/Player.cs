using System.ComponentModel.DataAnnotations;

namespace TrickHat.Data.Models
{
    public class Player
    {
        public int PlayerId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Team Team { get; set; }

        public int? TeamId { get; set; }
    }
}
