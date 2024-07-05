using System;
using System.Collections.Generic;
using System.IO;
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
using MainProject.ProfilePage_Parham.ProfilePage;
using MainProject.Public_Classes;
using MainProject.SignInPage_Matin;
using Newtonsoft.Json;
using MainProject.ProfilePage_Parham;
using MainProject.CustomerMainPage_Parham.CustomerMainPage;
using MainProject.RestaurantPanel_Parham.RestaurantPanel;
using MainProject.AdminPage_Parham.AdminPage;

namespace MainProject.LoginForm_Matin
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        List<User>? AllUser_List = new List<User>();
        List<Restaurant>? AllRestaurants_List = new List<Restaurant>();
        List<Admin>? AllAdmin_List = new List<Admin>();
        // MainProject\JsonFiles\User\All_Users.json


        public LoginPage()
        {
            InitializeComponent();

            AllUser_List = null;
            AllRestaurants_List = null;
            AllAdmin_List = null;
            string userJson = File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\User\All_Users.json");
            string adminJson = File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Admin\All_Admin.json");
            string RestaurantJson = File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Restaurant\All_Restaurant.json");
            //MessageBox.Show(userJson);
            if (!string.IsNullOrEmpty(userJson))
                AllUser_List = JsonConvert.DeserializeObject<List<User>?>(userJson);

            if (!string.IsNullOrEmpty(RestaurantJson))
                AllRestaurants_List = JsonConvert.DeserializeObject<List<Restaurant>>(RestaurantJson);

            if (!string.IsNullOrEmpty(adminJson))
                AllAdmin_List = JsonConvert.DeserializeObject<List<Admin>>(adminJson);

        }



        private void LoginBut(object sender, RoutedEventArgs e)
        {
            string username , password;
            username = UserName.TxtBox_M.Text;
            password=PassWord.TxtBox_M.Text;
            if (AllUser_List == null || AllUser_List.Count==0) { MessageBox.Show("WE HAVE NOT ANY USER"); return; }
            int i = 0;
            foreach(User user in AllUser_List)
            {
                if(user.PassWord==password && user.UserName==username)
                {

                    CustomerMainPage customerMainPage = new CustomerMainPage(AllUser_List[i]);
                    customerMainPage.Show();



                    this.Close();
                    return;
                }
                i++;
            }

            if (AllRestaurants_List == null || AllRestaurants_List.Count == 0) { MessageBox.Show("WE HAVE NOT ANY RESTAURANT"); return; }
            i = 0;
            foreach (Restaurant res in AllRestaurants_List)
            {
                if (res.PassWord == password && res.UserName == username)
                {
                    RestaurantPanel restaurantPanel = new RestaurantPanel(AllRestaurants_List[i]);
                    restaurantPanel.Show();
                    this.Close();
                    return;
                }
                i++;
            }


            if (AllAdmin_List == null || AllAdmin_List.Count == 0) { MessageBox.Show("WE HAVE NOT ANY ADMIN"); return; }
            i = 0;
            foreach (Admin admin in AllAdmin_List)
            {
                if (admin.Password == password && admin.UserName == username)
                {
                    AdminPage adminPage = new AdminPage(AllAdmin_List[i]);
                    adminPage.Show();


                    this.Close();
                    return;
                }
                i++;
            }

            MessageBox.Show("Are you sure you registered?\nPlease sign up first!","Attention" ,MessageBoxButton.OK,MessageBoxImage.Warning );
            SIGNbut.Focus();
        }

    private void SignBut(object sender, RoutedEventArgs e)
        {
            SignInForm signIn = new SignInForm(AllUser_List,AllRestaurants_List,AllAdmin_List);
            signIn.Show();
            this.Close();
        }
    }
}
