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
using MainProject.AddFood_Parham.AddFood;
using MainProject.ChangeFoodInformation_Parham.ChangeFoodInformation;

namespace MainProject.ChangeMenu_Parham.ChangeMenu
{
    public partial class ChangeMenu : Window
    {
        Restaurant restauranT;
        internal ChangeMenu(Restaurant restaurant)
        {
            InitializeComponent();
            restauranT = restaurant;
            List<FoodClass> menu = new List<FoodClass>();
            if(restauranT.Menu != null)
            {
                foreach (Category c in restaurant.Menu)
                {
                    foreach (FoodClass f in c.Foods)
                    {
                        menu.Add(f);
                    }
                }
                Menu.ItemsSource = menu;
            }
            else
            {
                Menu.ItemsSource = null;    
            }
        }
        private void Food_Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            FoodClass food = btn.DataContext as FoodClass;
            ChangeFoodInformation changeFoodInformation = new ChangeFoodInformation(food, restauranT);

        }
        private void Delete_Food_Button(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            FoodClass food = btn.DataContext as FoodClass;
            restauranT.RestaurantOverRide_DeletFood_InJsonFile(food);
            MessageBox.Show("the food is deleted", "Done", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        private void Add_A_Food_Button(Object sender, RoutedEventArgs e)
        {
            AddFood addFood = new AddFood(restauranT);
            this.Close();
            addFood.Show();
        }
    }
}
