using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Service.Models.Models.Db
{
    public class DbPlayer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<DbGameResult> GamesHistory { get; set; }
        public DbPlayer(Guid id, string userName)
        {
            Id = id;
            Name = userName;
            GamesHistory = new List<DbGameResult>();
        }
    }
}
