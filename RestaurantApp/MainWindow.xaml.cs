using RestaurantApp.CustomerMainPage_Parham.CustomerMainPage;
using RestaurantApp.LoginForm_Matin;
using RestaurantApp.Public_Classes;
using RestaurantApp.SignInPage_Matin;
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
using RestaurantApp.RestaurantPanel_Parham.RestaurantPanel;
using RestaurantApp.Public_Classes;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using RestaurantApp.AdminPage_Parham.AdminPage;
using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Org.BouncyCastle.Utilities;

namespace RestaurantApp
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string directory = MainWindow.GetSourceFileDirectory();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            directory = System.IO.Path.Combine(directory, @"LoginForm_Matin\BackMusic_Matin\Mix_BackMusic2.mp3");
            MusicWindowHIDE musicWindowHIDE = new MusicWindowHIDE(directory);
            musicWindowHIDE.Show();
            musicWindowHIDE.Hide();
            this.Close();
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
            //C:\User\ASUS\Desktop\Ap-402-Project\RestaurantApp
            string directory = MainWindow.GetSourceFileDirectory();
            string goal = System.IO.Path.Combine(directory, @"FoodImages");
            return goal;

        }

    }
}
