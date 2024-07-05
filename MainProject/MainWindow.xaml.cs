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
            User user = new User();
            user.Name = "Demo_Name";
            user.LastName = "Demo_LastName";
            user.Address = "This is a Address";
            user.Email_Unique = "Demo_Email@gmail.com";
            user.Gender = Gender.Female;
            user.Phone = "09123456789";
            user.UserName = "Demo_UserName";
            CustomerMainPage page = new CustomerMainPage(user);
            page.Show();
            this.Close();
        }
        
    }
}
