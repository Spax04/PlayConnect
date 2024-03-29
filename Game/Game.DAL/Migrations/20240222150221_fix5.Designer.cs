﻿// <auto-generated />
using System;
using Game.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Game.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240222150221_fix5")]
    partial class fix5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("Game.Models.Models.Connection", b =>
                {
                    b.Property<string>("ConnectionId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("ConnectionId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("Game.Models.Models.GamePlayerStat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GameTypeId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("TEXT");

                    b.Property<double>("Points")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("GameTypeId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GamePlayerStats");
                });

            modelBuilder.Entity("Game.Models.Models.GameResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GamePlayerStatsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GameSessionId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsWinner")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GamePlayerStatsId");

                    b.HasIndex("GameSessionId");

                    b.ToTable("GameResults");
                });

            modelBuilder.Entity("Game.Models.Models.GameSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GuestId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("HostId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("HostId");

                    b.ToTable("GameSessions");
                });

            modelBuilder.Entity("Game.Models.Models.GameType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GameTypes");
                });

            modelBuilder.Entity("Game.Models.Models.Move", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GameSessionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GameTypeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("MoveHistoryJson")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MoveNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameSessionId");

                    b.HasIndex("GameTypeId");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("Game.Models.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("InGame")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Game.Models.Models.Connection", b =>
                {
                    b.HasOne("Game.Models.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Game.Models.Models.GamePlayerStat", b =>
                {
                    b.HasOne("Game.Models.Models.GameType", "GameType")
                        .WithMany()
                        .HasForeignKey("GameTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Game.Models.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameType");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Game.Models.Models.GameResult", b =>
                {
                    b.HasOne("Game.Models.Models.GamePlayerStat", "GamePlayerStats")
                        .WithMany("Results")
                        .HasForeignKey("GamePlayerStatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Game.Models.Models.GameSession", "GameSession")
                        .WithMany()
                        .HasForeignKey("GameSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GamePlayerStats");

                    b.Navigation("GameSession");
                });

            modelBuilder.Entity("Game.Models.Models.GameSession", b =>
                {
                    b.HasOne("Game.Models.Models.Player", "Guest")
                        .WithMany()
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Game.Models.Models.Player", "Host")
                        .WithMany()
                        .HasForeignKey("HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Host");
                });

            modelBuilder.Entity("Game.Models.Models.Move", b =>
                {
                    b.HasOne("Game.Models.Models.GameSession", "GameSession")
                        .WithMany("Moves")
                        .HasForeignKey("GameSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Game.Models.Models.GameType", "GameType")
                        .WithMany()
                        .HasForeignKey("GameTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameSession");

                    b.Navigation("GameType");
                });

            modelBuilder.Entity("Game.Models.Models.GamePlayerStat", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("Game.Models.Models.GameSession", b =>
                {
                    b.Navigation("Moves");
                });
#pragma warning restore 612, 618
        }
    }
}
