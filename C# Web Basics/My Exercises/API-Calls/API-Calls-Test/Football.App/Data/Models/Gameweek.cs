using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football.App.Data.Models
{
    public class Gameweek
    {
        public int Id { get; init; }

        [Required]
        public string Name { get; init; }

        public int Number { get; init; }

        public DateTime? EndDate { get; set; }

        public bool IsFinished { get; set; }

        public ICollection<Fixture> Fixtures { get; set; } = new HashSet<Fixture>();

        public ICollection<PlayerGameweek> PlayerGameweeks { get; set; } = new HashSet<PlayerGameweek>();
    }
}
