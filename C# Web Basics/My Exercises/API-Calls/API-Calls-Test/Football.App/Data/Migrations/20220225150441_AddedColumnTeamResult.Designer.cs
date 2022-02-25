﻿// <auto-generated />
using System;
using Football.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Football.App.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220225150441_AddedColumnTeamResult")]
    partial class AddedColumnTeamResult
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Football.App.Data.Models.Fixture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AwayGoals")
                        .HasColumnType("int");

                    b.Property<int>("AwayTeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExternId")
                        .HasColumnType("int");

                    b.Property<int>("GameweekId")
                        .HasColumnType("int");

                    b.Property<int>("HomeGoals")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("GameweekId");

                    b.HasIndex("HomeTeamId");

                    b.ToTable("Fixtures");
                });

            modelBuilder.Entity("Football.App.Data.Models.Gameweek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Gameweeks");
                });

            modelBuilder.Entity("Football.App.Data.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int>("ExternId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Football.App.Data.Models.PlayerGameweek", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("GameweekId")
                        .HasColumnType("int");

                    b.Property<int>("BonusPoints")
                        .HasColumnType("int");

                    b.Property<bool>("CleanSheet")
                        .HasColumnType("bit");

                    b.Property<int>("ConcededGoals")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<bool>("InStartingLineup")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubstitute")
                        .HasColumnType("bit");

                    b.Property<int>("MinutesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("MissedPenalties")
                        .HasColumnType("int");

                    b.Property<int>("OwnGoals")
                        .HasColumnType("int");

                    b.Property<int>("RedCards")
                        .HasColumnType("int");

                    b.Property<int>("SavedPenalties")
                        .HasColumnType("int");

                    b.Property<int>("TeamResult")
                        .HasColumnType("int");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("int");

                    b.Property<int>("YellowCards")
                        .HasColumnType("int");

                    b.HasKey("PlayerId", "GameweekId");

                    b.HasIndex("GameweekId");

                    b.ToTable("PlayersGameweeks");
                });

            modelBuilder.Entity("Football.App.Data.Models.Stadium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ExternId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("Football.App.Data.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ExternId")
                        .HasColumnType("int");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("StadiumId")
                        .HasColumnType("int");

                    b.Property<int?>("TopPlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StadiumId");

                    b.HasIndex("TopPlayerId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Football.App.Data.Models.Fixture", b =>
                {
                    b.HasOne("Football.App.Data.Models.Team", "AwayTeam")
                        .WithMany("AwayFixtures")
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Football.App.Data.Models.Gameweek", "Gameweek")
                        .WithMany("Fixtures")
                        .HasForeignKey("GameweekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Football.App.Data.Models.Team", "HomeTeam")
                        .WithMany("HomeFixtures")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AwayTeam");

                    b.Navigation("Gameweek");

                    b.Navigation("HomeTeam");
                });

            modelBuilder.Entity("Football.App.Data.Models.Player", b =>
                {
                    b.HasOne("Football.App.Data.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Football.App.Data.Models.PlayerGameweek", b =>
                {
                    b.HasOne("Football.App.Data.Models.Gameweek", "Gameweek")
                        .WithMany("PlayerGameweeks")
                        .HasForeignKey("GameweekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Football.App.Data.Models.Player", "Player")
                        .WithMany("PlayerGameweeks")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gameweek");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Football.App.Data.Models.Team", b =>
                {
                    b.HasOne("Football.App.Data.Models.Stadium", "Stadium")
                        .WithMany("Teams")
                        .HasForeignKey("StadiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Football.App.Data.Models.Player", "TopPlayer")
                        .WithMany()
                        .HasForeignKey("TopPlayerId");

                    b.Navigation("Stadium");

                    b.Navigation("TopPlayer");
                });

            modelBuilder.Entity("Football.App.Data.Models.Gameweek", b =>
                {
                    b.Navigation("Fixtures");

                    b.Navigation("PlayerGameweeks");
                });

            modelBuilder.Entity("Football.App.Data.Models.Player", b =>
                {
                    b.Navigation("PlayerGameweeks");
                });

            modelBuilder.Entity("Football.App.Data.Models.Stadium", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Football.App.Data.Models.Team", b =>
                {
                    b.Navigation("AwayFixtures");

                    b.Navigation("HomeFixtures");

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
