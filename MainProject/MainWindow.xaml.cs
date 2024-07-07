using MainProject.CustomerMainPage_Parham.CustomerMainPage;
using MainProject.LoginForm_Matin;
using MainProject.Public_Classes;
using MainProject.SignInPage_Matin;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MainProject.RestaurantPanel_Parham.RestaurantPanel;
using MainProject.Public_Classes;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using MainProject.AdminPage_Parham.AdminPage;

namespace MainProject
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string jsonString = File.ReadAllText("C:\\Users\\ASUS\\Desktop\\All_Restaurant.json");
            List<Restaurant> restaurantsJsonData = System.Text.Json.JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
            RestaurantPanel restaurantPanel = new RestaurantPanel(restaurantsJsonData[0]);
            this.Close();
            restaurantPanel.Show();
        }
        
    }
}
