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
using MainProject.Public_Classes;
using MainProject.ChangeMenu_Parham.ChangeMenu;
using MainProject.OrderHistoryPage_Matin;
using MainProject.ChangeFoodInventory_Parham.ChangeFoodINverntory;
using MainProject.CustomerMainPage_Parham.CustomerMainPage;

namespace MainProject.RestaurantPanel_Parham.RestaurantPanel
{
    public partial class RestaurantPanel : Window
    {
        Restaurant restauranT;

        internal RestaurantPanel(Restaurant restaurant)
        {
            restauranT = restaurant;
            InitializeComponent();
        }
        private void Change_Menu(object sender, RoutedEventArgs e)
        {
            ChangeMenu changeMenu = new ChangeMenu(restauranT);
            this.Close();
            changeMenu.Show();
        }
        private void Change_food_inventory(object sender, RoutedEventArgs e)
        {
            if(restauranT.Menu != null)
            {
                ChangeFoodInverntory changeFoodInventoryPage = new ChangeFoodInverntory(restauranT);
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
                //restauranT.ActiveReservatio();
            }
            else
            {
                MessageBox.Show("Your rating is under 4.5.", "Rating Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void Order_and_reservation_history(object sender, RoutedEventArgs e)
        {
            OrderHistoryPage_CustomerPanel orderHistoryPage = new OrderHistoryPage_CustomerPanel(new CustomerMainPage(new User()));
            this.Close();
            orderHistoryPage.Show();
        }
    }
}
