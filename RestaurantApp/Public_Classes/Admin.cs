using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Public_Classes
{
    public class Admin
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Admin() { }
        public Admin(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
