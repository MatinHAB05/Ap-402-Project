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
using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Org.BouncyCastle.Utilities;

namespace MainProject
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            string directory = MainWindow.GetSourceFileDirectory();
            MessageBox.Show(directory);
            MessageBox.Show(Get_Dir_ALL_RESTAURANT_json());
            //C:\User\ASUS\Desktop\Ap-402-Project\MainProject

            //test
            //List<Restaurant> test = JsonConvert.DeserializeObject<List<Restaurant>>(File.ReadAllText(Get_Dir_ALL_RESTAURANT_json()));
            //List<User> testt= JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(Get_Dir_ALL_USERS_json()));
            //List<ReceptionComment> sda = JsonConvert.DeserializeObject<List<ReceptionComment>>(File.ReadAllText(Get_Dir_ALL_RECEPTION_COMMENT_json()));
            //List<Food_Point> asdadad = JsonConvert.DeserializeObject<List<Food_Point>>(File.ReadAllText(Get_Dir_ALL_FOOD_POINT_json()));
            //List<Reception_Point> asdasd = JsonConvert.DeserializeObject<List<Reception_Point>>(File.ReadAllText(Get_Dir_ALL_RECEPTION_POINT_json()));
            //List<FoodRequest> csd= JsonConvert.DeserializeObject<List<FoodRequest>>(File.ReadAllText(Get_Dir_ALL_FOOD_REQUEST_json()));
            //List<Complaint> trg= JsonConvert.DeserializeObject<List<Complaint>>(File.ReadAllText(Get_Dir_ALL_COMPLAINTS_json()));
            //List<Admin> xsdee = JsonConvert.DeserializeObject<List<Admin>>(File.ReadAllText(Get_Dir_ALL_ADMIN_json()));
            //test




            //matin start
            //User user = new User();
            //user.Name = "Demo_Name";
            //user.LastName = "Demo_LastName";
            //user.Address = "This is a Address";
            //user.Email_Unique = "m9652973@gmail.com";
            //user.Gender = Gender.Female;
            //user.Phone = "09123456789";
            //user.UserName = "Demo_UserName";
            //CustomerMainPage page = new CustomerMainPage(user);
            //page.Show();

            LoginPage loginPage = new LoginPage();
            loginPage.Show();

            //138397
            //string directory = MainWindow.GetSourceFileDirectory();
            //directory = System.IO.Path.Combine(directory, @"LoginForm_Matin\BackMusic_Matin\Mix_BackMusic2.mp3");
            //MusicWindowHIDE musicWindowHIDE = new MusicWindowHIDE(directory);
            //musicWindowHIDE.Show();
            //musicWindowHIDE.Hide();
            this.Close();
            //matin end



            //parham start
            string jsonString = File.ReadAllText(MainWindow.Get_Dir_ALL_RESTAURANT_json());
            //List<Restaurant> restaurantsJsonData = System.Text.Json.JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
            //RestaurantPanel restaurantPanel = new RestaurantPanel(restaurantsJsonData[0]);
            //this.Close();
            //restaurantPanel.Show();
            //parham end
        }



        static string GetSourceFileDirectory([CallerFilePath] string sourceFilePath = "")
        {
            return System.IO.Path.GetDirectoryName(sourceFilePath);
        }


        static public string Get_Dir_ALL_RESTAURANT_json()
        {
            string directory = MainWindow.GetSourceFileDirectory();
            string goal = System.IO.Path.Combine(directory, @"JsonFiles\Restaurant\All_Restaurant.json");
            return goal;
        }

        static public string Get_Dir_ALL_USERS_json()
        {
            string directory = MainWindow.GetSourceFileDirectory();
            string goal = System.IO.Path.Combine(directory, @"JsonFiles\User\All_Users.json");
            return goal;
        }

        static public string Get_Dir_ALL_RECEPTION_COMMENT_json()
        {
            string directory = MainWindow.GetSourceFileDirectory();
            string goal = System.IO.Path.Combine(directory, @"JsonFiles\ReceptionComment\All_ReceptionComment.json");
            return goal;
        }

        static public string Get_Dir_ALL_FOOD_POINT_json()
        {
            string directory = MainWindow.GetSourceFileDirectory();
            string goal = System.IO.Path.Combine(directory, @"JsonFiles\Points\All_Points.json");
            return goal;
        }


        static public string Get_Dir_ALL_RECEPTION_POINT_json()
        {
            string directory = MainWindow.GetSourceFileDirectory();
            string goal = System.IO.Path.Combine(directory, @"JsonFiles\Points\All_ReceptionPoint.json");
            return goal;
        }

        static public string Get_Dir_ALL_FOOD_REQUEST_json()
        {
            string directory = MainWindow.GetSourceFileDirectory();
            string goal = System.IO.Path.Combine(directory, @"JsonFiles\FoodRequest\All_FoodRequest.json");
            return goal;
        }

        static public string Get_Dir_ALL_COMPLAINTS_json()
        {
            string directory = MainWindow.GetSourceFileDirectory();
            string goal = System.IO.Path.Combine(directory, @"JsonFiles\Complaint\All_Complaints.json");
            return goal;
        }

        static public string Get_Dir_ALL_ADMIN_json()
        {
            string directory = MainWindow.GetSourceFileDirectory();
            string goal = System.IO.Path.Combine(directory, @"JsonFiles\Admin\All_Admin.json");
            return goal;
        }
        static public string Get_Dir_Images()
        {
            //C:\User\ASUS\Desktop\Ap-402-Project\MainProject
            string directory = MainWindow.GetSourceFileDirectory();
            string goal = System.IO.Path.Combine(directory, @"\FoodImages\");
            return goal;

        }

    }
}
