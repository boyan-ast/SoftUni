namespace FootballManager.Data
{
    using Microsoft.EntityFrameworkCore;
    using FootballManager.Data.Models;
    public class FootballManagerDbContext : DbContext
    {
        public FootballManagerDbContext()
        {

        }

        public DbSet<User> Users { get; init; }

        public DbSet<Player> Players { get; init; }

        public DbSet<UserPlayer> UserPlayers { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=FootballManager;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPlayer>()
                .HasKey(x => new { x.UserId, x.PlayerId });
        }
    }
}
