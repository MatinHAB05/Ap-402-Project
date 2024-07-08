using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Text.Json;

namespace MainProject.Public_Classes
{
    public class FoodClass
    {
        public string Name { get; set; }
        public int FoodID { get; set; }
        public double price { get; set; }
        public List<string>? Raw_Materials { get; set; }
        public double xBar { get; set; }
        public int RemNumber { get; set; }
        public List<FoodComment>? comments_IN_ORDER { get; set; }
        public string FoodCategory {  get; set; }
        public string? Image_Path { get; set; }

        public FoodClass() { }

        public FoodClass(string FoodCategory,string Name ,int FoodID ,double price, List<string> Raw_Materials , int  RemNumber , string? image_Path)
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
        public FoodClass(string FoodCategory, string Name, double price, List<string> Raw_Materials, int RemNumber, string? image_path)
        {
            this.FoodCategory = FoodCategory;
            this.Name = Name;
            this.price = price;
            this.Raw_Materials = Raw_Materials;
            this.xBar = 0;
            this.RemNumber = RemNumber;
            this.comments_IN_ORDER = new List<FoodComment>();
            this.Image_Path = image_path;
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

        public FoodClass cClone()
        {
            FoodClass c = new FoodClass();
            c.comments_IN_ORDER = new List<FoodComment>();
            c.Name = this.Name;
            c.FoodID = this.FoodID;
            c.price = this.price;
            c.xBar = this.xBar;
            c.RemNumber = this.RemNumber;
            c.FoodCategory = this.FoodCategory;
            c.Image_Path = this.Image_Path;
            if (Raw_Materials == null) { c.Raw_Materials = null; }
            else { 
            foreach (string X in Raw_Materials) { c.Raw_Materials.Add(X); }
                }
            //MessageBox.Show(this.comments_IN_ORDER.Count.ToString() + "asdadas");
            foreach (FoodComment fc in this.comments_IN_ORDER) { c.comments_IN_ORDER.Add(fc.cCloneComment()); }

            return c;
        }
        public void xBarCalculate()
        {
            double FPSum = 0;
            int numberOfFoodPoints = 0;
            string jsonString = File.ReadAllText("C:\\Users\\ASUS\\Desktop\\All_Points.json");
            List<Food_Point> foodPointsJsonData = System.Text.Json.JsonSerializer.Deserialize<List<Food_Point>>(jsonString);
            foreach (Food_Point FP in foodPointsJsonData)
            {
                if (FP.FoodID == this.FoodID)
                {
                    FPSum += (double)FP.Point;
                    numberOfFoodPoints += 1;
                }
            }
            this.xBar = FPSum / numberOfFoodPoints;
        }



    }
}
