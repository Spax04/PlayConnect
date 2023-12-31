﻿// <auto-generated />
using System;
using Chat.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Chat.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.13");

            modelBuilder.Entity("Chat_Models.Models.Chatter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsConnected")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastSeen")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Chatters");
                });

            modelBuilder.Entity("Chat_Models.Models.Connection", b =>
                {
                    b.Property<string>("ConnectionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChatterId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("ConnectionId");

                    b.HasIndex("ChatterId");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("Chat_Models.Models.Message", b =>
                {
                    b.Property<Guid>("MessageeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsReceived")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NewMessage")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReceivedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RecipientId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("TEXT");

                    b.HasKey("MessageeId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Chat_Models.Models.Connection", b =>
                {
                    b.HasOne("Chat_Models.Models.Chatter", "Chatter")
                        .WithMany("Connections")
                        .HasForeignKey("ChatterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chatter");
                });

            modelBuilder.Entity("Chat_Models.Models.Message", b =>
                {
                    b.HasOne("Chat_Models.Models.Chatter", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chat_Models.Models.Chatter", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Chat_Models.Models.Chatter", b =>
                {
                    b.Navigation("Connections");
                });
#pragma warning restore 612, 618
        }
    }
}
