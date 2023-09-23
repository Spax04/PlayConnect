using Game.Service.Models.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace Game.Service.DAL.Data
{
    public class GameDataContext : DbContext
    {
        public GameDataContext(DbContextOptions<GameDataContext> options) : base(options) { }

        public DbSet<DbPlayer> Players { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbPlayer>().HasMany(p => p.GamesHistory)
                .WithOne()
                .HasForeignKey(h => h.DbPlayerId);
        }

    }
}