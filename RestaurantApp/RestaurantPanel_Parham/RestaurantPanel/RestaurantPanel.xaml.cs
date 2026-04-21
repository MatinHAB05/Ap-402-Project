using RestaurantApp.Public_Classes;
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
using RestaurantApp.Public_Classes;
using RestaurantApp.ChangeMenu_Parham.ChangeMenu;
using RestaurantApp.OrderHistoryPage_Matin;
using RestaurantApp.ChangeFoodInventory_Parham.ChangeFoodINverntory;
using RestaurantApp.CustomerMainPage_Parham.CustomerMainPage;
using Application = System.Windows.Application;
using RestaurantApp.LoginForm_Matin;

namespace RestaurantApp.RestaurantPanel_Parham.RestaurantPanel
{
    public partial class RestaurantPanel : Window
    {
        Restaurant restauranT;
        public bool Window_Event { get; set; }
        internal RestaurantPanel(Restaurant restaurant)
        {
            restauranT = restaurant;
            this.Window_Event = true;
            InitializeComponent();
        }
        private void Change_Menu(object sender, RoutedEventArgs e)
        {
            ChangeMenu changeMenu = new ChangeMenu(restauranT);
            this.Window_Event = false;
            this.Close();
            changeMenu.Show();
        }
        private void Change_food_inventory(object sender, RoutedEventArgs e)
        {
            if(restauranT.Menu != null)
            {
                ChangeFoodInverntory changeFoodInventoryPage = new ChangeFoodInverntory(restauranT);
                this.Window_Event = false;
                this.Close();
                changeFoodInventoryPage.Show();
            }
            else
            {
                MessageBox.Show("your menu is empty, please enter a food first", "empty menu", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Activate_the_reservation_service(object sender, RoutedEventArgs e)
        {
            if(restauranT.Rating >= 4.5)
            {
                restauranT.ActiveReservation();
                MessageBox.Show("reservation status changed", "successfully changed", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Your rating is under 4.5.", "Rating Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }
        private void Order_and_reservation_history(object sender, RoutedEventArgs e)
        {

        }
        private void Logout(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            this.Window_Event = false;
            this.Close();
            loginPage.Show();
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
