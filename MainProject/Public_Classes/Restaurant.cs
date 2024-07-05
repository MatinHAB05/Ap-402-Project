using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows;

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
        static public FoodClass? Get_Food_FromFoodID(int foodId,Restaurant Res)
        {
            string json = File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Restaurant\All_Restaurant.json");
            List<Restaurant> restaurants=JsonConvert.DeserializeObject<List<Restaurant>>(json);
            int i = 0;
            if (Res.Menu == null)
            {
                return null;
            }
            foreach(Category cat in Res.Menu)
            {
                
                foreach(FoodClass fc in cat.Foods)
                {
                    if(fc.FoodID == foodId)
                    {
                        return fc;
                    }
                }
                i++; ;
            }

            //MessageBox.Show(foodId.ToString());
            //MessageBox.Show((foodId==null).ToString());

            return null;
        }

        static public Restaurant? GetFromUserName(string UserName)
        {
            string json = File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Restaurant\All_Restaurant.json");
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
            MessageBox.Show(UserName);
            //MessageBox.Show((UserName=="").ToString());

            return null;
        }
        static public Restaurant? GetFromname(string Name)
        {
            string json = File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Restaurant\All_Restaurant.json");
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
        //public void RestaurantOverRide_AddFood_InJsonFile(FoodClass food, Category category)
        //{
        //    if(this.Menu != null)
        //    {
        //        foreach (Category c in this.Menu)
        //        {
        //            if (c.Name == category.Name)
        //            {
        //                c.Foods.Add(food);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        this.Menu = new List<Category>();
        //    }
        //    string jsonString = File.ReadAllText("C:\\Users\\ASUS\\Desktop\\All_Restaurant.json");
        //    List<Restaurant> restaurantsJsonData = JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
        //    foreach(Restaurant r in restaurantsJsonData)
        //    {
        //        if(r.RestaurantName == this.RestaurantName)
        //        {
        //            if(r.Menu != null)
        //            {
        //                MessageBox.Show("yes", "yes", MessageBoxButton.YesNo, MessageBoxImage.Question);
        //                foreach (Category c in r.Menu)
        //                {
        //                    if (c.Name == category.Name)
        //                    {
        //                        c.Foods.Add(food);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                bool happendeOrNot = true;
        //                r.Menu = new List<Category>();
        //                List<FoodClass> foods = new List<FoodClass>();
        //                r.Menu.Add(new Category(category.Name, foods));
        //                foreach (Category c in r.Menu)
        //                {
        //                    c.Foods.Add(food);
        //                    happendeOrNot = false;
        //                }
        //            }
        //        }
        //    }
        //   jsonString = JsonSerializer.Serialize(restaurantsJsonData, new JsonSerializerOptions
        //    {
        //        WriteIndented = true
        //    });
        //    File.WriteAllText("C:\\Users\\ASUS\\Desktop\\All_Restaurant.json", jsonString);
        //}
        //public void RestaurantOverRide_DeletFood_InJsonFile(FoodClass food)
        //{
        //    foreach (Category c in this.Menu)
        //    {
        //        for (int i = 0; i < c.Foods.Count; i++)
        //        {
        //            if ((c.Foods[i].Name == food.Name) && (c.Foods[i].price == food.price))
        //            {
        //                c.Foods.Remove(c.Foods[i]);
        //            }
        //        }
        //    }
        //    string jsonString = File.ReadAllText("C:\\Users\\ASUS\\Desktop\\All_Restaurant.json");
        //    List<Restaurant> restaurantsJsonData = JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
        //    foreach (Restaurant r in restaurantsJsonData)
        //    {
        //        if (r.RestaurantName == this.RestaurantName)
        //        {
        //            foreach (Category c in r.Menu)
        //            {
        //                for (int i = 0; i < c.Foods.Count; i++)
        //                {
        //                    if ((c.Foods[i].Name == food.Name) && (c.Foods[i].price == food.price))
        //                    {
        //                        MessageBox.Show("yes", "yes", MessageBoxButton.YesNo, MessageBoxImage.Question);
        //                        c.Foods.Remove(c.Foods[i]);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    jsonString = JsonSerializer.Serialize(restaurantsJsonData, new JsonSerializerOptions
        //    {
        //        WriteIndented = true
        //    });
        //    File.WriteAllText("C:\\Users\\ASUS\\Desktop\\All_Restaurant.json", jsonString);
        //}
        //public void RestaurantOverRide_ChangeRem_InJsonFile(FoodClass food, int Remaining)
        //{
        //    foreach(Category c in this.Menu)
        //    {
        //        for (int i = 0; i < c.Foods.Count; i++)
        //        {
        //            if ((c.Foods[i].Name == food.Name) && (c.Foods[i].price == food.price))
        //            {
        //                c.Foods[i].RemNumber = Remaining;
        //            }
        //        }
        //    }
        //    string jsonString = File.ReadAllText("C:\\Users\\ASUS\\Desktop\\All_Restaurant.json");
        //    List<Restaurant> restaurantsJsonData = JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
        //    foreach (Restaurant r in restaurantsJsonData)
        //    {
        //        if (r.RestaurantName == this.RestaurantName)
        //        {
        //            foreach (Category c in r.Menu)
        //            {
        //                for (int i = 0; i < c.Foods.Count; i++)
        //                {
        //                    if ((c.Foods[i].Name == food.Name) && (c.Foods[i].price == food.price))
        //                    {
        //                        c.Foods[i].RemNumber = Remaining;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    jsonString = JsonSerializer.Serialize(restaurantsJsonData, new JsonSerializerOptions
        //    {
        //        WriteIndented = true
        //    });
        //    File.WriteAllText("C:\\Users\\ASUS\\Desktop\\All_Restaurant.json", jsonString);
        //}
        //public void ActiveReservatio()
        //{
        //string jsonString = File.ReadAllText("C:\\Users\\ASUS\\Desktop\\All_Restaurant.json");
        //List<Restaurant> restaurantsJsonData = JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
        //foreach (Restaurant r in restaurantsJsonData)
        //{
        //    if (r.RestaurantName == this.RestaurantName)
        //    {
        //        r.IsCanReserve = !r.IsCanReserve;
        //    }
        //}
        //jsonString = JsonSerializer.Serialize(restaurantsJsonData, new JsonSerializerOptions
        //{
        //    WriteIndented = true
        //});
        //File.WriteAllText("C:\\Users\\ASUS\\Desktop\\All_Restaurant.json", jsonString);
        //}
    }
}
