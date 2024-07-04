using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Public_Classes
{
    public class Restaurant
    {
        public string UserName { get; set; }
        public int UserID { get; set; }

        public double Rating { get; set; }
        public string PassWord { get; set; }
        public string CityName { get; set; }
        public string RestaurantName { get; set; }
        public ReceptionType receptionType { get; set; }
        public string AddreesOfRestaurant {  get; set; }

        public bool IsCanReserve = false;
        public List<Category> Menu { get; set; }
        public Restaurant() { }
         public Restaurant(string UserName, int UserID, string RestaurantName, string PassWord, string CityName, bool IsCanReserve, List<Category> Menu, ReceptionType receptionType)
        {
            this.UserName = UserName;
            this.UserID = UserID;
            this.RestaurantName = RestaurantName;
            this.PassWord = PassWord;
            this.CityName = CityName;
            this.IsCanReserve = IsCanReserve;
            this.Menu = Menu;
            this.receptionType = receptionType;
            this.Rating = 0;
        }
        static public Restaurant? GetFromUserName(string UserName)
        {
            string json = File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\MainProject\JsonFiles\Restaurant\All_Restaurant.json");
            List<Restaurant> restaurants=JsonConvert.DeserializeObject<List<Restaurant>>(json);
            int i = 0;
            int j = 0;
            foreach(Restaurant r in restaurants)
            {
                if(r.UserName == UserName)
                {
                    j++;
                    break;
                }
                i++; ;
            }
            if(j==1)
            return restaurants[i];
            return null;
        }
        static public Restaurant? GetFromname(string Name)
        {
            string json = File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\MainProject\JsonFiles\Restaurant\All_Restaurant.json");
            List<Restaurant> restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);
            int i = 0;
            int j = 0;
            foreach (Restaurant r in restaurants)
            {
                if (r.RestaurantName == Name)
                {
                    j++;
                    break;
                }
                i++; ;
            }
            if (j == 1)
                return restaurants[i];
            return null;
        }
        public void Calculate()
        {
            double sum = 0;
            int NumberOfFoodsCounter = 0;
            foreach (Category c in Menu)
            {
                foreach (FoodClass f in c.Foods)
                {
                    NumberOfFoodsCounter += 1;
                    sum += f.xBar;
                }
            }
        }
    }
}