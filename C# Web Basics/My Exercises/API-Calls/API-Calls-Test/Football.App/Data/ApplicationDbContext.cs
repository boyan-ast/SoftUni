using Football.App.Common;
using Football.App.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Football.App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; init; }

        public DbSet<Player> Players { get; init; }

        public DbSet<Stadium> Stadiums { get; init; }

        public DbSet<Gameweek> Gameweeks { get; init; }

        public DbSet<Fixture> Fixtures { get; init; }

        public DbSet<PlayerGameweek> PlayersGameweeks { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Constants.ConnectionString);
                optionsBuilder
                    .EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);

            modelBuilder.Entity<Fixture>()
                .HasOne(f => f.HomeTeam)
                .WithMany(ht => ht.HomeFixtures)
                .HasForeignKey(f => f.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Fixture>()
                .HasOne(f => f.AwayTeam)
                .WithMany(ht => ht.AwayFixtures)
                .HasForeignKey(f => f.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlayerGameweek>()
                .HasKey(x => new { x.PlayerId, x.GameweekId });
        }
    }
}
