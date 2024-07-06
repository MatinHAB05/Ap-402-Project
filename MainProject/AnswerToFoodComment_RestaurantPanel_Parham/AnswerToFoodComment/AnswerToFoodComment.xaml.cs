using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MainProject.Public_Classes;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;

namespace MainProject.AnswerToFoodComment_RestaurantPanel_Parham.AnswerToFoodComment
{
    public partial class AnswerToFoodComment : Window
    {
        FoodComment food_Comment;
        Restaurant restauranT;
        public AnswerToFoodComment(Restaurant restaurant, FoodComment foodComment)
        {
            this.food_Comment = foodComment;
            this.restauranT = restaurant;   
            UserTitle.Text = foodComment.Title;
            UserText.Text = foodComment.Content;
            AnswerFormIntro.Text = "Answering" + foodComment.User_UserName + "Comment";
            InitializeComponent();
        }
        private void Answer_Completed(object sender, RoutedEventArgs e)
        {
            FoodComment? foodComment = new FoodComment(food_Comment.Title + "Reply", AnswerText.Text, null, restauranT.UserName);
            string json = File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Restaurant\All_Restaurant.json");
            List<Restaurant> restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);
            List<Restaurant> restaurantsExceptOurs = restaurants.Where(x => x.RestaurantName != restauranT.RestaurantName).ToList();
            List<Restaurant> OurRestaurant = restaurants.Where(x => x.RestaurantName == restauranT.RestaurantName && x.UserName == restauranT.UserName).ToList();
            foreach(Category c in OurRestaurant[0].Menu)
            {
                foreach(FoodClass f in c.Foods)
                {
                    foreach(FoodComment fc in f.comments_IN_ORDER)
                    {
                        if(fc.User_UserName == food_Comment.User_UserName)
                        {
                            fc.Reply.Add(foodComment);
                        }
                    }
                }
            }
            restaurantsExceptOurs.AddRange(OurRestaurant);
            string jsonString = System.Text.Json.JsonSerializer.Serialize(restaurantsExceptOurs, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("C:\\Users\\ASUS\\Desktop\\All_Restaurant.json", jsonString);
        }
    }
}
