using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Public_Classes
{
    public class Reception_Point
    {
        public int RequestID {  get; set; }
        public double Point { get; set; }
        public string UserName { get; set; }
        public int UserID { get; set; }
        public Reception_Point() { }
        public Reception_Point(int FoodID, int RequestID, double Point, string UserName, int UserID)
        {
            this.RequestID = RequestID;
            this.Point = Point;
            this.UserName = UserName;
            this.UserID = UserID;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Public_Classes
{
    public class Reception_Point
    {
        public int RequestID {  get; set; }
        public double Point { get; set; }
        public string UserName { get; set; }
        public int UserID { get; set; }
        public Reception_Point() { }
        public Reception_Point(int FoodID, int RequestID, double Point, string UserName, int UserID)
        {
            this.RequestID = RequestID;
            this.Point = Point;
            this.UserName = UserName;
            this.UserID = UserID;
        }

    }
}
