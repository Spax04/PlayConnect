using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Dto.Requests
{
    public class GameTypeCreateRequest
    {
        public string? Name { get; set; }
        public byte[] Image { get; set; }
    }
}
