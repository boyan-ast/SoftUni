﻿using Football.App.Common;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Constants.ConnectionString);
            }
        }
    }
}