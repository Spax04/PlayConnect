using Game.DAL.Data;
using Game.DAL.Interfaces;
using Game.Models.Dto.Requests;
using Game.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Game.DAL.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly DataContext _context;
        public GameRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<GameSession?> CreateGameSessionAsync(Guid hostId, Guid guestId)
        {
            var newGameSession = new GameSession()
            {
                Id = Guid.NewGuid(),
                HostId = hostId,
                GuestId = guestId,
                IsFinished = false,
            };

            await _context.GameSessions.AddAsync(newGameSession);
            return await Save() ? newGameSession : null;
        }

        public async Task CreateGameTypeAsync(GameTypeCreateRequest gameType)
        {
            var newGameType = new GameType()
            {
                Id = Guid.NewGuid(),
                Name = gameType.Name,
                Image = gameType.Image
            };

            await _context.GameTypes.AddAsync(newGameType);
            await Save();
        }

        public async Task<bool> UpdateSessionTimeAsync(Guid gameSessionId, bool isStarted)
        {
            GameSession gameSession = await _context.GameSessions!.FirstOrDefaultAsync(x => x.Id == gameSessionId);

            if (gameSession != null)
            {
                if (isStarted)
                    gameSession.StartTime = DateTime.UtcNow;
                else
                    gameSession.EndTime = DateTime.UtcNow;
            }

            return await Save();
        }

        public async Task<IEnumerable<GameType>> GetGameTypesAsync()
        {
            return await _context.GameTypes.ToListAsync();
        }

        public async Task<GameType> GetGameTypeByIdAsync(Guid gameTypeId)
        {
            return await _context.GameTypes.FirstOrDefaultAsync(x => x.Id == gameTypeId);
        }

        public async Task<bool> SaveGameMoveAsync(Move move)
        {
            await _context.Moves.AddAsync(move);

            return await Save();
        }

        public async Task<GamePlayerStat> GetGamePlayerStatByPlayerAndGameIdAsync(Guid playerId, Guid gameTypeId)
        {
            return await _context.GamePlayerStats.FirstOrDefaultAsync(gp => gp.GameTypeId == gameTypeId && gp.PlayerId == playerId);
        }
        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<GamePlayerStat> CreateGamePlayerStats(Guid gameTypeId, Guid playerId)
        {
            GamePlayerStat newGamePlayerStat = new GamePlayerStat()
            {
                Id = Guid.NewGuid(),
                GameTypeId = gameTypeId,
                PlayerId = playerId,
                Level = 1,
                Points = 0
            };
            await _context.GamePlayerStats.AddAsync(newGamePlayerStat);

            if (await Save()){
                return newGamePlayerStat;
            }
            else
            {
               throw new Exception();
            }

        }

        public async Task<bool> UpdateGamePlayerStatsAsync(Guid playerId, Guid gameTypeId, int lvl, double points)
        {
            GamePlayerStat gamePlayerStats = await GetGamePlayerStatByPlayerAndGameIdAsync(playerId, gameTypeId);

            gamePlayerStats.Points = points;
            gamePlayerStats.Level = lvl;

            return await Save();
        }

        public async Task<bool> CreateGameResultAsync(Guid sessionId, Guid gamePlayerStats, Guid gameTypeId, Guid playerId, Guid opponentId, bool isWinner)
        {
            GameResult newGameResult = new GameResult()
            {
                Id = Guid.NewGuid(),
                GameSessionId = sessionId,
                GameTypeId = gameTypeId,
                PlayerId = playerId,
                OpponentId = opponentId,
                PlayedAt = DateTime.UtcNow,
                IsWinner = isWinner
            };

            await _context.GameResults.AddAsync(newGameResult);
            return await Save();
        }

        public async Task<GameResult> GetGameResultBySessionIdAsync(Guid sessionId )
        {
            return  await _context.GameResults.FirstOrDefaultAsync(gr => gr.GameSessionId == sessionId);

        }
    }
}
