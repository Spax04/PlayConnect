﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.DAL.Interfaces
{
    public interface IPlayerService
    {
        Task<bool> IsPlayerExistAsync(Guid playerId);
        Task<bool> UpdateInGamePlayerStatus(Guid playerId,bool status);
    }
}
