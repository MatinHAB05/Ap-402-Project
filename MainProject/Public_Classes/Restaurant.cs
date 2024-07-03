using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Public_Classes
{
    internal class Restaurant
    {
        public string UserName {  get; set; }
        public int UserID {  get; set; }

        public int Rating { get; set; }
        public string PassWord {  get; set; }
        public string CityName {  get; set; }
        public string RestaurantName {  get; set; }
        public ReceptionType receptionType { get; set; }

        public bool IsCanReserve=false;
        public List<Category> Menu { get; set; }

        public Restaurant(string UserName ,int UserID, string RestaurantName, string PassWord , string CityName , bool IsCanReserve, List<Category> Menu , ReceptionType receptionType)
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
        public void Calculate()
        {
            double sum = 0;
            int NumberOfFoodsCounter = 0;
            foreach(Category c in Menu)
            {
                foreach(FoodClass f in c.Foods)
                {
                    NumberOfFoodsCounter += 1;
                    sum += f.xBar;
                }
            }
        }
    }
}
