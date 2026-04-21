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
using MainProject.RestaurantPanel_Parham.RestaurantPanel;
using Application = System.Windows.Application;

namespace MainProject.ChangeMenu_Parham.ChangeMenu
{
    public partial class ChangeMenu : Window
    {
        Restaurant restauranT;
        List<FoodClass> menu;
        public bool Window_Event { get; set; }
        internal ChangeMenu(Restaurant restaurant)
        {
            this.Window_Event = true;
            InitializeComponent();
            restauranT = restaurant;
             menu = new List<FoodClass>();
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
            this.Window_Event = false;
            this.Close();
            changeFoodInformation.Show();
        }
        private void Delete_Food_Button(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            FoodClass food = btn.DataContext as FoodClass;
            menu.Remove(food);
            Menu.ItemsSource = menu;
            restauranT.RestaurantOverRide_DeletFood_InJsonFile(food);
            MessageBox.Show("the food is deleted", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
            ChangeMenu changeMenu = new ChangeMenu(restauranT);
            changeMenu.Show();
            this.Window_Event = false;
            this.Close();
        }
        private void Add_A_Food_Button(Object sender, RoutedEventArgs e)
        {
            AddFood addFood = new AddFood(restauranT);
            this.Window_Event = false;
            this.Close();
            addFood.Show();
        }
        private void BackPage(object sender, RoutedEventArgs e)
        {
            
            RestaurantPanel restaurantPanel = new RestaurantPanel(restauranT);
            this.Window_Event = false;
            this.Close();
            restaurantPanel.Show();
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
