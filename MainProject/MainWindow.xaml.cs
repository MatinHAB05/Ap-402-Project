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
            
            //matin start
            User user = new User();
            user.Name = "Demo_Name";
            user.LastName = "Demo_LastName";
            user.Address = "This is a Address";
            user.Email_Unique = "m9652973@gmail.com";
            user.Gender = Gender.Female;
            user.Phone = "09123456789";
            user.UserName = "Demo_UserName";
            CustomerMainPage page = new CustomerMainPage(user);
            page.Show();


            //LoginPage loginPage = new LoginPage();
            //loginPage.Show();

            MusicWindowHIDE musicWindowHIDE = new MusicWindowHIDE(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\LoginForm_Matin\BackMusic_Matin\Mix_BackMusic2.mp3");
            musicWindowHIDE.Show();
            musicWindowHIDE.Hide();
            this.Close();
            //matin end
            
            
            
            //parham start
            string jsonString = File.ReadAllText("C:\\Users\\ASUS\\Desktop\\All_Restaurant.json");
            List<Restaurant> restaurantsJsonData = System.Text.Json.JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
            RestaurantPanel restaurantPanel = new RestaurantPanel(restaurantsJsonData[0]);
            this.Close();
            restaurantPanel.Show();
            //parham end
        }
        
    }
}
