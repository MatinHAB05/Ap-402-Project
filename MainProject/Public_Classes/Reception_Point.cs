using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;

namespace MainProject.Public_Classes
{
    public class Reception_Point
    {
        public int RequestID {  get; set; }
        public double? Point { get; set; }
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
        static public Reception_Point? GetFromjson(int reqid)
        {
            List<Reception_Point>? reception_Points = JsonConvert.DeserializeObject<List<Reception_Point>>(File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Points\All_ReceptionPoint.json"));
            if (reception_Points == null) { return null; }
            foreach(Reception_Point r in reception_Points)
            {
                if(r.RequestID == reqid) return r;
            }
            //MessageBox.Show(reqid.ToString());
            return null;
        }

    }
}
