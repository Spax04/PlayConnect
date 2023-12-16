using Game.Models.Models;
using Game.Models.Tic_Tac_Toe;
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
        public DbSet<TicTacToeMove> TicTacToeMoves { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TicTacToeMove>().ToTable("TicTacToeMoves");

            base.OnModelCreating(modelBuilder);

        }

    }
}