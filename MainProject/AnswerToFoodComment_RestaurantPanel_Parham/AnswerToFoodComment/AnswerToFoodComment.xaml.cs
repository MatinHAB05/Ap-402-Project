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
using MainProject.ChangeFoodInformation_Parham.ChangeFoodInformation;
using MainProject.ChangeMenu_Parham.ChangeMenu;

namespace MainProject.AnswerToFoodComment_RestaurantPanel_Parham.AnswerToFoodComment
{
    public partial class AnswerToFoodComment : Window
    {
        FoodComment food_Comment;
        Restaurant restauranT;
        FoodClass fooD;
        public AnswerToFoodComment(Restaurant restaurant, FoodComment foodComment, FoodClass food)
        {
            InitializeComponent();
            fooD = food;
            this.food_Comment = foodComment;
            this.restauranT = restaurant;   
            UserTitle.Text = foodComment.Title;
            UserText.Text = foodComment.Content;
            AnswerFormIntro.Text = "Answering " + foodComment.User_UserName + " Comment";

        }
        private void Answer_Completed(object sender, RoutedEventArgs e)
        {
            FoodComment foodComment = new FoodComment(food_Comment.Title + " Reply", AnswerText.Text, null, restauranT.UserName);
            MessageBox.Show(AnswerText.Text + " Reply", "hai", MessageBoxButton.OK, MessageBoxImage.Error);
            string json = File.ReadAllText("C:\\Users\\ASUS\\Desktop\\All_Restaurant.json");
            List<Restaurant> restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);
            List<Restaurant> restaurantsExceptOurs = restaurants.Where(x => x.RestaurantName != restauranT.RestaurantName).ToList();
            List<Restaurant> OurRestaurant = restaurants.Where(x => x.RestaurantName == restauranT.RestaurantName && x.UserName == restauranT.UserName).ToList();

            foreach(Category c in OurRestaurant[0].Menu)
            {
                foreach(FoodClass f in c.Foods)
                {
                    bool HappendOrNot = true;
                    foreach (FoodComment fc in f.comments_IN_ORDER)
                    {
                        if(HappendOrNot)
                        {
                            if (fc.Title == food_Comment.Title  && fc.CommentID == food_Comment.CommentID)
                            {
                                
                                if (fc.Reply != null)
                                {

                                    fc.Reply.Add(foodComment);
                                }
                                else
                                {
                                    fc.Reply = new List<FoodComment?>();
                                    fc.Reply.Add(foodComment);
                                }
                                HappendOrNot = false;
                            }
                        }
                    }
                }
            }
            restaurantsExceptOurs.AddRange(OurRestaurant);
            string jsonString = JsonConvert.SerializeObject(restaurantsExceptOurs, Formatting.Indented);
            File.WriteAllText("C:\\Users\\ASUS\\Desktop\\All_Restaurant.json", jsonString);
        }
        private void BackPage(object sender, RoutedEventArgs e)
        {
            ChangeFoodInformation changeFoodInformation = new ChangeFoodInformation(fooD, restauranT);
            this.Close();
            changeFoodInformation.Show();
        }

    }
}
