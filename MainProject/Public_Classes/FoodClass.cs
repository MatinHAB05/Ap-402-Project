using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace MainProject.Public_Classes
{
    public class FoodClass
    {
        public string Name { get; set; }
        public int FoodID { get; set; }
        public double price { get; set; }
        public List<string> Raw_Materials { get; set; }
        public double xBar { get; set; }
        public int RemNumber { get; set; }
        public List<FoodComment> comments_IN_ORDER { get; set; }
        public string FoodCategory {  get; set; }
        public string Image_Path { get; set; }

        public FoodClass() { }

        public FoodClass(string FoodCategory,string Name ,int FoodID ,double price, List<string> Raw_Materials , int  RemNumber , string image_Path)
        {
            this.FoodCategory = FoodCategory;
            this.Name = Name;
            this.FoodID = FoodID;
            this.price = price;
            this.Raw_Materials = Raw_Materials;
            this.xBar = 0;
            this.RemNumber = RemNumber;
            this.comments_IN_ORDER = new List<FoodComment>();
            this.Image_Path = image_Path;
        }
        public FoodClass(string FoodCategory, string Name, double price, List<string> Raw_Materials, int RemNumber)
        {
            this.FoodCategory = FoodCategory;
            this.Name = Name;
            this.price = price;
            this.Raw_Materials = Raw_Materials;
            this.xBar = 0;
            this.RemNumber = RemNumber;
            this.comments_IN_ORDER = new List<FoodComment>();
            string json = File.ReadAllText("C:\\Users\\ASUS\\Desktop\\All_Restaurant.json");
            List<Restaurant> restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);
            int numberOfFoods = 0;
            foreach (Restaurant re in restaurants)
            {
                foreach (Category category in re.Menu)
                {
                    numberOfFoods += category.Foods.Count();
                }
            }
            FoodID = numberOfFoods + 1;
        }



    }
}
