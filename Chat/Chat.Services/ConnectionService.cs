using Chat.DAL.Interfaces;
using Chat.Services.Interfaces;


namespace Chat.Services
{
    public class ConnectionService : IConnectionService
    {
        readonly IChatterRepository _chatterRepo;
        readonly IConnectionRepository _chatRepo;

        public ConnectionService(IChatterRepository chatterRepo, IConnectionRepository chatRepo)
        {
            _chatterRepo = chatterRepo;
            _chatRepo = chatRepo;
        }

        p


    }
}