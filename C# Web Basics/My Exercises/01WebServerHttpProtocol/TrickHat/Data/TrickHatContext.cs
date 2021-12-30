using Microsoft.EntityFrameworkCore;
using TrickHat.Data.Models;

namespace TrickHat.Data
{
    public class TrickHatContext : DbContext
    {
        public TrickHatContext()
        {

        }

        public TrickHatContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
