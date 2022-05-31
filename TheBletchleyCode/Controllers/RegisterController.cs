using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBletchleyCode.Models;

namespace TheBletchleyCode.Controllers
{
    class RegisterController
    {
        public void AddUser(PlayerInfoTable p)
        {
            using (PlayerDBEntities ex = new PlayerDBEntities())
            {
                var lastPlayer = ex.PlayerInfoTable.ToList().LastOrDefault();
                if (lastPlayer == null)
                {
                    lastPlayer = new PlayerInfoTable();
                    lastPlayer.Id = 0;
                }
                p.Id = lastPlayer.Id + 1;
                ex.PlayerInfoTable.Add(p);
                ex.SaveChanges();
            }
        }
    }
}
