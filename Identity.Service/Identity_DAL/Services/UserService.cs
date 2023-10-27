using Identity_DAL.Interfaces;
using Identity_Models.Dto.Responses;
using Identity_Models.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_DAL.Services
{
    public class UserService : IUserService
    {
       
        public async  Task<IEnumerable<ChatterResponse>> GetFriendsAreOnline(string userId)
        {
            List<ChatterResponse> result = new List<ChatterResponse>();
            using (var client = new HttpClient())
            {
                string url = string.Format($"http://localhost:7112/api/user/friends/{userId}");
                var response = client.GetAsync(url).Result;

                string responseAsString = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<ChatterResponse>>(responseAsString);
            }

           return result;
        }

        public async Task<Response> IsUserOnline(string userId)
        {
            Response isOnline;
            using (var client = new HttpClient())
            {
                string url = string.Format($"http://localhost:7112/api/chatter/isonline/{userId}");
                var response =  client.GetAsync(url).Result;

                string responseAsString = await response.Content.ReadAsStringAsync();
                isOnline = JsonConvert.DeserializeObject<Response>(responseAsString);
            }

            return isOnline;
        }
    }
}
