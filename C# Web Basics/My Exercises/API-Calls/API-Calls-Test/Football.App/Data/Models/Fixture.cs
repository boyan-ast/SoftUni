using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Football.App.Data.Models
{
    public class Fixture
    {
        public int Id { get; set; }

        public int ExternId { get; set; }

        public int GameweekId { get; set; }

        public Gameweek Gameweek { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }

        public Team HomeTeam { get; set; }

        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; set; }

        public Team AwayTeam { get; set; }

        [Required]
        [MaxLength(5)]
        public string Status { get; set; }

        //TODO: Add home team goals and away team goals
    }
}
