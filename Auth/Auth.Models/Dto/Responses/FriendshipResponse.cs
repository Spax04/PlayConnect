using Auth.Models.Helpers;

namespace Auth.Models.Dto.Responses
{
    public class FriendshipResponse : Response
    {
        public FriendshipResponse() : base(true)
        {
        }

        public List<OtherUserResponse> AcceptedFriends { get; set; }
        public List<OtherUserResponse> PendingFriends { get; set; }
    }
}
