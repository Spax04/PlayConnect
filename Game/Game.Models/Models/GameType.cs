﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Models
{
    public class GameType
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }

    }
}
