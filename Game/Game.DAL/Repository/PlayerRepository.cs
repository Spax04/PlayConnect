﻿using Game.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.DAL.Repository
{
    public class PlayerRepository
    {
        DataContext _context;
        public PlayerRepository(DataContext context)
        {
            _context = context;
        }
    }
}