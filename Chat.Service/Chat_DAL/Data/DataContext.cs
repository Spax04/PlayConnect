using Chat_Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Chat_DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public DbSet<Connection>? Connections { get; set; }
        public DbSet<Message>? Messages { get; set; }
        public DbSet<Chatter>? Chatters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Chatter>()
       .HasMany(ch => ch.Connections)
       .WithOne(c => c.Chatter)
       .HasForeignKey(c => c.ChatterId);
/*
            builder.Entity<Chatter>()
                .HasMany(ch => ch.Chats)
                .WithOne(c => c.ChatterTwo)
                .HasForeignKey(c => c.ChatterTwoId);*/

            /*            builder.Entity<Chatter>()
                    .HasMany(ch => ch.Chats)
                    .WithOne();*/
        }
    }
}