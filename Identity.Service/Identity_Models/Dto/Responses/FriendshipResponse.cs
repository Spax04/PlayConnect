using Identity_Models.Helpers;

namespace Identity_Models.Dto.Responses
{
    public class FriendshipResponse : Response
    {
        public FriendshipResponse() : base(true)
        {
        }

        public List<OtherUserResponse> Friends { get; set; }
        public List<OtherUserResponse> PendingFrineds { get; set; }
    }
}
