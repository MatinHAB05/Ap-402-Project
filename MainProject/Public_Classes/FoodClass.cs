using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public FoodClass(string FoodCategory,string Name ,int FoodID ,double price, List<string> Raw_Materials , double xBar , int  RemNumber , List<FoodComment> comments_IN_Order , string image_Path)
        {
            this.FoodCategory = FoodCategory;
            this.Name = Name;
            this.FoodID = FoodID;
            this.price = price;
            this.Raw_Materials = Raw_Materials;
            this.xBar = xBar;
            this.RemNumber = RemNumber;
            this.comments_IN_ORDER = comments_IN_Order;
            this.Image_Path = image_Path;
        }



    }
}
