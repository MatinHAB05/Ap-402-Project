using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows;


namespace RestaurantApp.Public_Classes
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
            string json = File.ReadAllText(MainWindow.Get_Dir_ALL_RESTAURANT_json());
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
            string json = File.ReadAllText(MainWindow.Get_Dir_ALL_RESTAURANT_json());
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
                i++; 
            }
            if(j==1)
            return restaurants[i];
            MessageBox.Show(UserName);
            //MessageBox.Show((UserName=="").ToString());

            return null;
        }
        static public Restaurant? GetFromname(string Name)
        {
            string json = File.ReadAllText(MainWindow.Get_Dir_ALL_RESTAURANT_json());
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
            foreach (Category c in this.Menu)
            {
                foreach (FoodClass f in c.Foods)
                {
                    f.xBarCalculate();
                    NumberOfFoodsCounter += 1;
                    sum += f.xBar;
                }
            }
            double ReqSum = 0;
            int numberOfFoodRequests = 0;
            string jsonString = File.ReadAllText(MainWindow.Get_Dir_ALL_RECEPTION_POINT_json());
            List<Reception_Point> ReceptionPointsJsonData = System.Text.Json.JsonSerializer.Deserialize<List<Reception_Point>>(jsonString);
            string jsonString2 = File.ReadAllText(MainWindow.Get_Dir_ALL_FOOD_REQUEST_json());
            List<FoodRequest> FoodRequestesJsonData = System.Text.Json.JsonSerializer.Deserialize<List<FoodRequest>>(jsonString);
            foreach (Reception_Point RP in ReceptionPointsJsonData)
            {
                foreach(FoodRequest FR in FoodRequestesJsonData)
                {
                    if(FR.RequestID == RP.RequestID && FR.RestaurantUserName == this.UserName)
                    {
                        ReqSum += (double)RP.Point;
                        numberOfFoodRequests += 1;
                    }
                }
            }
            this.Rating = (ReqSum + sum) / (NumberOfFoodsCounter + numberOfFoodRequests);
        }
        public void RestaurantOverRide_AddFood_InJsonFile(FoodClass food, Category category)
        {
            if (this.Menu != null)
            {
                bool happendeOrNot = true;
                for (int i = 0; i < this.Menu.Count(); i++)
                {
                    if (this.Menu[i].Name == category.Name)
                    {
                        this.Menu[i].Foods.Add(food);
                        happendeOrNot = false;
                        break;
                    }
                }
                if (happendeOrNot)
                {
                    List<FoodClass> foods = new List<FoodClass>();
                    this.Menu.Add(new Category(category.Name, foods));
                    this.Menu[this.Menu.Count()-1].Foods.Add(food);
                }
            }
            else
            {
                this.Menu = new List<Category>();
                this.Menu[0].Foods.Add(food);
            }
            string jsonString = File.ReadAllText(MainWindow.Get_Dir_ALL_RESTAURANT_json());
            List<Restaurant> restaurantsJsonData = System.Text.Json.JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
            List<Restaurant> restaurantsExceptOurs = restaurantsJsonData.Where(x => x.RestaurantName != this.RestaurantName).ToList();
            List<Restaurant> OurRestaurant = restaurantsJsonData.Where(x => x.RestaurantName == this.RestaurantName && x.UserName == this.UserName).ToList();
            if (OurRestaurant[0].Menu != null)
            {
                bool HappendOrNot = true;
                foreach (Category c in OurRestaurant[0].Menu)
                {
                    if (c.Name == category.Name)
                    {
                        c.Foods.Add(food);
                        HappendOrNot = false;
                    }
                }
                if (HappendOrNot)
                {
                    bool happendeOrNot2 = true;
                    List<FoodClass> foods = new List<FoodClass>();
                    OurRestaurant[0].Menu.Add(new Category(category.Name, foods));
                    foreach (Category c in OurRestaurant[0].Menu)
                    {
                        if(c.Name == category.Name)
                        {
                            c.Foods.Add(food);
                            happendeOrNot2 = false;
                        }
                    }
                }
            }
            else
            {
                bool happendeOrNot = true;
                OurRestaurant[0].Menu = new List<Category>();
                List<FoodClass> foods = new List<FoodClass>();
                OurRestaurant[0].Menu.Add(new Category(category.Name, foods));
                foreach (Category c in OurRestaurant[0].Menu)
                {
                    c.Foods.Add(food);
                    happendeOrNot = false;
                }
            }
            restaurantsExceptOurs.AddRange(OurRestaurant);
            jsonString = JsonConvert.SerializeObject(restaurantsExceptOurs, Formatting.Indented);
            File.WriteAllText(MainWindow.Get_Dir_ALL_RESTAURANT_json(), jsonString);
        }
        public void RestaurantOverRide_DeletFood_InJsonFile(FoodClass food)
        {
            foreach (Category c in this.Menu)
            {
                for (int i = 0; i < c.Foods.Count; i++)
                {
                    if ((c.Foods[i].Name == food.Name) && (c.Foods[i].price == food.price))
                    {
                        c.Foods.Remove(c.Foods[i]);
                    }
                }
            }
            string jsonString = File.ReadAllText(MainWindow.Get_Dir_ALL_RESTAURANT_json());
            List<Restaurant> restaurantsJsonData = System.Text.Json.JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
            List<Restaurant> restaurantsExceptOurs = restaurantsJsonData.Where(x => x.RestaurantName != this.RestaurantName).ToList();
            List<Restaurant> OurRestaurant = restaurantsJsonData.Where(x => x.RestaurantName == this.RestaurantName && x.UserName == this.UserName).ToList();
            foreach (Category c in OurRestaurant[0].Menu)
            {
                for (int i = 0; i < c.Foods.Count; i++)
                {
                    if ((c.Foods[i].Name == food.Name) && (c.Foods[i].price == food.price))
                    {
                        c.Foods.Remove(c.Foods[i]);
                    }
                }
            }
            restaurantsExceptOurs.AddRange(OurRestaurant);
            jsonString = JsonConvert.SerializeObject(restaurantsExceptOurs, Formatting.Indented);
            File.WriteAllText(MainWindow.Get_Dir_ALL_RESTAURANT_json(), jsonString);
        }
        public void RestaurantOverRide_ChangeRem_InJsonFile(FoodClass food, int Remaining)
        {
            bool happendOrNot = true;
            foreach (Category c in this.Menu)
            {
                for (int i = 0; i < c.Foods.Count; i++)
                {
                    if ((c.Foods[i].Name == food.Name) && (c.Foods[i].price == food.price))
                    {
                        c.Foods[i].RemNumber = Remaining;
                        happendOrNot = false;
                        break;
                    }
                }
            }
            string jsonString = File.ReadAllText(MainWindow.Get_Dir_ALL_RESTAURANT_json());
            List<Restaurant> restaurantsJsonData = System.Text.Json.JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
            List<Restaurant> restaurantsExceptOurs = restaurantsJsonData.Where(x => x.RestaurantName != this.RestaurantName).ToList();
            List<Restaurant> OurRestaurant = restaurantsJsonData.Where(x => x.RestaurantName == this.RestaurantName && x.UserName == this.UserName).ToList();
            foreach (Category c in OurRestaurant[0].Menu)
            {
                for (int i = 0; i < c.Foods.Count; i++)
                {
                    if ((c.Foods[i].Name == food.Name) && (c.Foods[i].price == food.price))
                    {
                        c.Foods[i].RemNumber = Remaining;
                    }
                }
            }
            restaurantsExceptOurs.AddRange(OurRestaurant);
            jsonString = JsonConvert.SerializeObject(restaurantsExceptOurs, Formatting.Indented);
            File.WriteAllText(MainWindow.Get_Dir_ALL_RESTAURANT_json(), jsonString);
        }
        public void ActiveReservation()
        {
            string jsonString = File.ReadAllText(MainWindow.Get_Dir_ALL_RESTAURANT_json());
            List<Restaurant> restaurantsJsonData = System.Text.Json.JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
            List<Restaurant> restaurantsExceptOurs = restaurantsJsonData.Where(x => x.RestaurantName != this.RestaurantName).ToList();
            List<Restaurant> OurRestaurant = restaurantsJsonData.Where(x => x.RestaurantName == this.RestaurantName && x.UserName == this.UserName).ToList();
            bool happendOrNot = true;
            if (OurRestaurant.Any())
            {
                if (OurRestaurant[0].IsCanReserve && happendOrNot)
                {
                    OurRestaurant[0].IsCanReserve = false;
                }
                else if (!OurRestaurant[0].IsCanReserve && happendOrNot)
                {
                    OurRestaurant[0].IsCanReserve = true;
                }
            }
            restaurantsExceptOurs.AddRange(OurRestaurant);
            jsonString = JsonConvert.SerializeObject(restaurantsExceptOurs, Formatting.Indented);
            File.WriteAllText(MainWindow.Get_Dir_ALL_RESTAURANT_json(), jsonString);
        }
    }
}
