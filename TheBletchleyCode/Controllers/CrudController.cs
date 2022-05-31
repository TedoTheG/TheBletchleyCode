using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBletchleyCode.Models;

namespace TheBletchleyCode.Controllers
{
    class CrudController
    {
        public List<PlayerInfoTable> GetAll()
        {
            using (PlayerDBEntities ex = new PlayerDBEntities())
            {
                return ex.PlayerInfoTable.ToList();
            }
        }
        public void CreatePlayer(PlayerInfoTable f)
        {
            using (PlayerDBEntities db = new PlayerDBEntities())
            {
                var lastUser = db.PlayerInfoTable.ToList().LastOrDefault();
                if (lastUser == null)
                {
                    lastUser = new PlayerInfoTable();
                    lastUser.Id = 0;
                }

                f.Id = lastUser.Id + 1;
                db.PlayerInfoTable.Add(f);
                db.SaveChanges();
            }
        }

        public static void DeletePlayer(int id)
        {
            using (PlayerDBEntities ex = new PlayerDBEntities())
            {
                var playerDelete = ex.PlayerInfoTable.Where(f => f.Id == id).FirstOrDefault();
                if (playerDelete != null)
                {
                    ex.PlayerInfoTable.Remove(playerDelete);
                    ex.SaveChanges();
                }
            }
        }

        public static void UpdatePlayer(int id, PlayerInfoTable f)
        {
            using (PlayerDBEntities ex = new PlayerDBEntities())
            {
                var playerUpdate = ex.PlayerInfoTable.Where(p => p.Id == id).FirstOrDefault();
                if (playerUpdate != null)
                {
                    playerUpdate.Id = f.Id;
                    playerUpdate.Name = f.Name;
                    playerUpdate.Password = f.Password;
                    ex.SaveChanges();
                }
            }
        }

    }
}
