using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MainProject.Public_Classes
{
    internal class Food_Point
    {
        public int FoodID { get; set; }
        public int RestuantID {  get; set; }
        public double Point {  get; set; }
        public string UserName { get; set; }
        public int UserID { get; set; }
        public Food_Point() { }
        public Food_Point(int FoodID, int ResturantID , double Point , string UserName , int UserID)
        {
            this.FoodID = FoodID;
            this.RestuantID = ResturantID;
            this.Point = Point;
            this.UserName = UserName;
            this.UserID = UserID;
        } 

    }
}
