using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBletchleyCode.Models;

namespace TheBletchleyCode.Controllers
{
    class LoginController
    {
        public string ShowMessage(string username, string password)
        {
            using (PlayerDBEntities ex = new PlayerDBEntities())
            {
                var existingPlayer = ex.PlayerInfoTable.Where(s => s.Name == username).FirstOrDefault();
                if (existingPlayer != null)
                {
                    if (existingPlayer.Password == password)
                    {
                        return null;
                    }
                    else
                    {
                        return "Wrong Password!";
                    }
                }
                else
                {
                    return "No such User!";
                }
            }
        }
            
    }
}

