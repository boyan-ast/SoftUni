using System.ComponentModel.DataAnnotations;

using Football.App.Data.Models.Enums;

namespace Football.App.Data.Models
{
    public class Player
    {
        [Key]
        public int Id { get; init; }

        public int ExternId { get; init; }

        [MaxLength(40)]
        public string Name { get; init; }

        public int? Age { get; set; }

        public int? Number { get; set; }

        public Position Position { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }
    }
}
