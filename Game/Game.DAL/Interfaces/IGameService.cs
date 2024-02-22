namespace Game.DAL.Interfaces
{
    public interface IGameService
    {

        bool IsStartsFirst();
        Task<bool> RecognizeAndSaveGameMoveAsync(Guid gameTypeId, string gameMove);
    }
}
