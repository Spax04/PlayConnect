using Game.Service.DAL.Data;
using Game.Service.Models.Models;
using Game.Service.Models.Models.Db;
using Game.Service.Models.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Service.DAL
{
    public class PlayerRepository
    {
        GameDataContext _context;
        public PlayerRepository(GameDataContext context)
        {
            _context = context;
        }
        public void AddPlayer(Guid id, string username)
        {
            _context.Players.Add(new DbPlayer(id, username));
        }
        public Player GetPlayer(Guid playerId, string connectionId)
        {
            DbPlayer dbPlayer = _context.Players.Find(playerId);
            _context.Entry(dbPlayer).Collection(p => p.GamesHistory).Load();
            Player player = new Player(dbPlayer.Id, dbPlayer.Name, connectionId, dbPlayer.GamesHistory.ToList());
            return player;
        }
        public void UpdatePlayersResutls(DbGameResult winnerResult, DbGameResult looserResult) 
        {
            DbPlayer winnerPlayer = _context!.Players!.Find(winnerResult.DbPlayerId);
            _context?.Entry(winnerPlayer).Collection(p => p.GamesHistory).Load();
            winnerPlayer.GamesHistory.Add(winnerResult);

            DbPlayer losserPlayer = _context.Players.Find(looserResult.DbPlayerId);
            _context.Entry(losserPlayer).Collection(p => p.GamesHistory).Load();
            losserPlayer.GamesHistory.Add(looserResult);

            _context.SaveChanges();
        }

    }
}
