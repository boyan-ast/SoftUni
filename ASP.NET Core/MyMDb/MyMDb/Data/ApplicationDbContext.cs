namespace MyMDb.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MyMDb.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; init; }

        public DbSet<Genre> Genres { get; init; }

        public DbSet<UserMovie> UsersMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Movie>()
                .HasOne(m => m.Creator)
                .WithMany(c => c.CreatedMovies)
                .HasForeignKey(m => m.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<UserMovie>()
                .HasKey(x => new { x.UserId, x.MovieId });

            base.OnModelCreating(builder);
        }
    }
}
