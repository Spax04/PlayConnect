using AutoMapper;
using Backgammon_Backend.Data;
using Identity_DAL.Authorization.Interfaces;
using Identity_DAL.AuthorizationUtilits.Interfaces;
using Identity_DAL.Repositories.Interfaces;
using Identity_Models.DTO.Registration;
using Identity_Models.Helpers;
using Identity_Models.Users;
using Identity_Models.Users.Dto.User;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;
        private readonly IConfiguration _config;
        private IJwtUtilits _jwtUtilits;
        public UserRepository(
            DataContext context,
            IConfiguration config,
            IJwtUtilits jwtUtilits
            )
        {
            _context = context;
            _config = config;
            _jwtUtilits = jwtUtilits;
        }

        private Response GetUserById(string userID)
        {
            if(!Guid.TryParse(userID, out var userIdDb))
            {
                return new FailedResponse("Id is not correct");
            }

            var user = _context.Users.First(x=> x.UserId == userIdDb);
            if(user == null)
            {
                return new FailedResponse("This user does not exist");
            }

            return new UserResponse()
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                ImgUrl = user.ImgUrl,

            };


        }
        public Task<Response> GetUserByIdAsync(string userID) => Task.Run(() => GetUserById(userID));
    }
}
