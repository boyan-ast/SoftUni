using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football.App.Data.Models
{
    public class Team
    {
        [Key]
        public int Id { get; init; }

        public int ExternId { get; init; }

        [MaxLength(40)]
        public string Name { get; init; }

        public string Logo { get; init; }

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();

        public int StadiumId { get; set; }

        public Stadium Stadium { get; set; }

        [ForeignKey(nameof(TopPlayer))]
        public int? TopPlayerId { get; set; }

        public Player TopPlayer { get; set; }
    }
}
