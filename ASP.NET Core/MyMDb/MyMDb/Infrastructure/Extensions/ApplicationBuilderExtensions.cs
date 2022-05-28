namespace MyMDb.Infrastructure.Extensions
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MyMDb.Data;
    using MyMDb.Data.Models;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedGenres(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();
        }

        private static void SeedGenres(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.Genres.Any())
            {
                return;
            }

            data.Genres.AddRange(new[]
            {
                new Genre { Name = "Action" },
                new Genre { Name = "Romance" },
                new Genre { Name = "Thriller" },
                new Genre { Name = "Sports" },
                new Genre { Name = "Comedy" },
                new Genre { Name = "Sci-Fi" },
                new Genre { Name = "Horror" },
                new Genre { Name = "TV Series" }
            });

            data.SaveChanges();
        }
    }
}
