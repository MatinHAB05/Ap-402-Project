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
using MainProject.RestaurantPanel_Parham.RestaurantPanel;
using MainProject.ChangeMenu_Parham.ChangeMenu;
using Application = System.Windows.Application;

namespace MainProject.ChangeFoodInformation_Parham.ChangeFoodInformation
{
    
    public partial class ChangeFoodInformation : Window
    {
        FoodClass fooD;
        Restaurant restauranT;
        public bool Window_Event { get; set; }
        public ChangeFoodInformation(FoodClass food, Restaurant restaurant)
        {
            this.Window_Event = true;
            InitializeComponent();
            fooD = food;
            restauranT = restaurant;
            Name.Text = food.Name;
            Price.Text = Convert.ToString(food.price);
            if(food.Raw_Materials !=  null)
            {
                Raw_Materials.Text = string.Join(',', food.Raw_Materials);
            }
            else
            {
                Raw_Materials.Text = "_";
            }
            Food_Category.Text = food.FoodCategory;
            Comments.ItemsSource = food.comments_IN_ORDER;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(food.Image_Path, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            Comments.ItemsSource = food.comments_IN_ORDER;
            Img.Source = bitmap;
        }
        private void Answer_Comment_Button(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            FoodComment foodComment = btn.DataContext as FoodComment;
            AnswerToFoodComment answerToFoodComment = new AnswerToFoodComment(restauranT, foodComment, fooD);
            this.Window_Event = false;
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
                FoodClass Food = new FoodClass(Food_Category.Text, Name.Text, _price, RawMats, fooD.RemNumber, fooD.Image_Path);
                restauranT.RestaurantOverRide_DeletFood_InJsonFile(fooD);
                restauranT.RestaurantOverRide_AddFood_InJsonFile(Food, new Category(Food_Category.Text, null));
            }
            MessageBox.Show("changes have been saved","saved",MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void BackPage(object sender, RoutedEventArgs e)
        {
            
            ChangeMenu changeMenu = new ChangeMenu(restauranT);
            this.Window_Event = false;
            this.Close();
            changeMenu.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.Window_Event)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
