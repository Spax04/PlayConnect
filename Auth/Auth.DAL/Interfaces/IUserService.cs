﻿using Auth.Models.Dto.Responses;
using Auth.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DAL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<ChatterResponse>> GetFriendsAreOnline(string userId);
        Task<Response> IsUserOnline(string userId);
    }
}
