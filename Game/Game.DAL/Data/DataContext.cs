using Game.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Game.DAL.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Player> Players { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<GameResult> GameResults { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<GamePlayerStat> GamePlayerStats { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);

        }

    }
}