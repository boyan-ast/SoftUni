using System.ComponentModel.DataAnnotations;

namespace Football.App.Data.Models
{
    public class Stadium
    {
        [Key]
        public int Id { get; init; }

        public int ExternId { get; init; }

        [MaxLength(40)]
        public string Name { get; init; }

        [MaxLength(20)]
        public string City { get; init; }

        public int Capacity { get; init; }

        public string Image { get; init; }

        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    }
}
