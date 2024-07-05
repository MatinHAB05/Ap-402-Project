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

namespace MainProject.AddFood_Parham.AddFood
{
    public partial class AddFood : Window
    {
        Category Category;
        int foodRemNumber;
        List<string> FoodMaterial;
        string FoodName;
        string CategoryName;
        double price;
        Restaurant restauranT;
        internal AddFood(Restaurant restaurant)
        {
            restauranT = restaurant;
            InitializeComponent();
        }
        private void Complete_Click(object sender, RoutedEventArgs e)
        {
            if ((Price.Text != "") && (Category_Name.Text != "") && (Food_Name.Text != "") && (Materials.Text != "") && (Remaine_Number.Text != ""))
            {
                bool ContinueOrNot = true;
                try
                {
                    this.price = Convert.ToDouble(Price.Text);

                }
                catch
                {
                    MessageBox.Show("Your Entered Price was not right", "Number Wrong", MessageBoxButton.OK, MessageBoxImage.Error);
                    ContinueOrNot = false;
                }
                if (ContinueOrNot)
                {
                    try
                    {
                        this.foodRemNumber = Convert.ToInt32(Remaine_Number.Text);

                    }
                    catch
                    {
                        MessageBox.Show("Your Entered Remained number was not right", "Number Wrong", MessageBoxButton.OK, MessageBoxImage.Error);
                        ContinueOrNot = false;
                    }
                }
                if (ContinueOrNot)
                {
                    this.CategoryName = Category_Name.Text;
                    this.FoodName = Food_Name.Text;
                    this.FoodMaterial = Materials.Text.Split(',').ToList<string>();
                    FoodClass food = new FoodClass(this.CategoryName, this.FoodName, this.price , this.FoodMaterial, this.foodRemNumber);
                    //this.restauranT.RestaurantOverRide_AddFood_InJsonFile(food, new Category(this.CategoryName, null));
                }
            }
            else
            {
                MessageBox.Show("Please Enter all fields", "You did not enter all fields",  MessageBoxButton.OK , MessageBoxImage.Error);
            }
        }
    }
}
