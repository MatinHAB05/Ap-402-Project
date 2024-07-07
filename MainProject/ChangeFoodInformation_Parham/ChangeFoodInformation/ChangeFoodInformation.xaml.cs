using MainProject.Public_Classes;
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
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Imaging;
using MainProject.AnswerToFoodComment_RestaurantPanel_Parham.AnswerToFoodComment;

namespace MainProject.ChangeFoodInformation_Parham.ChangeFoodInformation
{
    
    public partial class ChangeFoodInformation : Window
    {
        FoodClass fooD;
        Restaurant restauranT;
        public ChangeFoodInformation(FoodClass food, Restaurant restaurant)
        {
            InitializeComponent();
            fooD = food;
            restauranT = restaurant;
            Name.Text = food.Name;
            Price.Text = Convert.ToString(food.price);
            Raw_Materials.Text = string.Join(',', food.Raw_Materials);
            Food_Category.Text = food.FoodCategory;
            //BitmapImage bitmap = new BitmapImage();
            //bitmap.BeginInit();
            //bitmap.UriSource = new Uri(food.Image_Path, UriKind.RelativeOrAbsolute);
            //bitmap.EndInit();
            //Comments.ItemsSource = food.comments_IN_ORDER;
            //Img.Source = bitmap;
            //we will make it tommorow
        }
        private void Answer_Comment_Button(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            FoodComment foodComment = btn.DataContext as FoodComment;
            AnswerToFoodComment answerToFoodComment = new AnswerToFoodComment(restauranT, foodComment);
            this.Close();
            answerToFoodComment.Show();

        }
        private void Done(object sender, RoutedEventArgs e)
        {
            bool isPriceOk = true;
            double _price = 0;
            List<string> RawMats= new List<string>();
            try
            {
                _price = Convert.ToDouble(Price.Text);
                RawMats = Raw_Materials.Text.Split(',').ToList();
            }
            catch
            {
                isPriceOk = false;
            }
            if(isPriceOk)
            {
                FoodClass Food = new FoodClass(Food_Category.Text, Name.Text, _price, RawMats, fooD.RemNumber);
                restauranT.RestaurantOverRide_DeletFood_InJsonFile(fooD);
                restauranT.RestaurantOverRide_AddFood_InJsonFile(Food, new Category(Food_Category.Text, null));
            }
        }
    }
}
