using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MainProject.Public_Classes
{
    public class Food_Point
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

        public static Food_Point? FindFoodPointFromJSON(int foodID ,string userNName)
        {
            List<Food_Point> All = JsonConvert.DeserializeObject<List<Food_Point>>(File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Points\All_Points.json"));
            foreach(Food_Point fff in All)
            {
                if(fff.FoodID == foodID && fff.UserName==userNName)
                {
                    return fff;
                }
            }
            return null;
        }

    }
}
