using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MainProject.AdminPage_Parham.AdminPage;
using MainProject.Public_Classes;
using MimeKit.Utils;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MainProject.AddRestunts_AdminPanel_Matin
{
    /// <summary>
    /// Interaction logic for AddRestunts_AdminPanel_Page.xaml
    /// </summary>
    public partial class AddRestunts_AdminPanel_Page : Window
    {
        bool Must_OFF ;

        public Admin admin {  get; set; }
        public List<Restaurant>? restaurants {  get; set; }
        public List<Admin>? admins { get; set; }
        public List<User>? users { get; set; }

        public AddRestunts_AdminPanel_Page(Admin admin)
        {
            InitializeComponent();
            Must_OFF = true;
            restaurants = GetAllRes(MainWindow.Get_Dir_ALL_RESTAURANT_json());
            users = GetAllUser(MainWindow.Get_Dir_ALL_USERS_json());
            admins = GetAllAdmin(MainWindow.Get_Dir_ALL_ADMIN_json());
            this.admin = admin;
        }
        //*****************************************************************************************
        private void AddResturnatsBut(object sender, RoutedEventArgs e)
        {
            int flag = 0;
            string username = UserName.TxtBox_M.Text.Trim();
            string addres = Addres.Text.Trim();
            string city = City.Text.Trim();
            string resName= Restuanname.Text.Trim();

            string Error = "";
            bool IsUserName = true;
            bool IsName = true;
            bool IsUnq = true;

            if (!Regex.IsMatch(username, @"^[A-Za-z0-9]{3,}$"))
            {
                Error += "نام کاربری فقط شامل اعداد و حروف کوچک و بزرگ انگلیسی متشکل از حداقل 3 حرف باید باشد" + "\n";
                IsUserName = false;
            }
            if (!Regex.IsMatch(resName, @"^[A-Za-z]{3,32}$"))
            {
                Error += "اسم رستوران باید شامل حداقل 3 و حداکثر 32 حرف باشد و اعداد و کارکتر های نگارشی مورد قبول نیست" + "\n";
            }
            if (!Regex.IsMatch(city, @"^[A-Za-z]{3,32}$"))
            {
                Error += "اسم شهر باید شامل حداقل 3 و حداکثر 32 حرف باشد و اعداد و کارکتر های نگارشی مورد قبول نیست" + "\n";
            }
            if (addres == "")
            {
                Error += "ادرس نمیتواند خالی باشد" + "\n";
            }
            if(ra2.IsChecked == false && ra1.IsChecked == false && ra3.IsChecked==false)
            {
                Error += "نوع رستوران باید مشخص شود" + "\n";

            }



            if (Error != "")
            {
            matinLabel:
                MessageBoxResult a = MessageBox.Show(Error + "ردیفه؟", "UNVALID INPUT", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (a == MessageBoxResult.Yes) { return; }
                if (a == MessageBoxResult.No) { goto matinLabel; }
            }
            else
            {
                foreach (Restaurant r in restaurants)
                {
                    if (r.UserName == username)
                    {
                        IsUnq = false;

                        MessageBox.Show("این نام کاربری ثبت شده است", "Unvalid Inputs", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;

                    }
                    if (r.RestaurantName == resName)
                    {
                        MessageBox.Show("این نام برای رستوران ثبت شده است", "Unvalid Inputs", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                foreach (Admin a in admins)
                {
                    if (a.UserName == username)
                    {
                        IsUnq = false;
                        MessageBox.Show("این نام کاربری ثبت شده است", "Unvalid Inputs", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;

                    }
                }


                foreach (User u in users)
                {
                    if (u.UserName == username)
                    {
                        IsUnq = false;
                        MessageBox.Show("این نام کاربری ثبت شده است", "Unvalid Inputs", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;

                    }
                }


                Restaurant demo = new Restaurant();
                demo.UserName = username;
                demo.AddreesOfRestaurant = addres;
                demo.PassWord= (new Random()).Next(10000000, 99999999).ToString();
                demo.CityName = city;
                demo.RestaurantName = resName;
                demo.Menu = new List<Category>();

                demo.receptionType = ReceptionType.Dine_In;
                if (ra1.IsChecked==true) { demo.receptionType=ReceptionType.Dine_In; }
                else if (ra2.IsChecked == true) { demo.receptionType = ReceptionType.Delivery; }
                else if (ra3.IsChecked == true) { demo.receptionType = ReceptionType.Both; }


                restaurants.Add(demo);

                File.WriteAllText(MainWindow.Get_Dir_ALL_RESTAURANT_json(),
                    JsonConvert.SerializeObject(restaurants,Formatting.Indented));



                MessageBox.Show($"Hey {resName}!\nYour Pass is {demo.PassWord}","Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;

            }
        }

        private void EditPassBut(object sender, RoutedEventArgs e)
        {
            int flag = 0;
            string username = UserName.TxtBox_M.Text.Trim();
            string pass = PassWord.TxtBox_M.Text;
            string Error = "";
            bool IsUserName = true;
            bool Ispass = true;
            bool Bflag=false;

            if (!Regex.IsMatch(username, @"^[A-Za-z0-9]{3,}$"))
            {
                Error += "نام کاربری فقط شامل اعداد و حروف کوچک و بزرگ انگلیسی متشکل از حداقل 3 حرف باید باشد" + "\n";
                IsUserName = false;
            }

            if (!Regex.IsMatch(pass, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{8,32}$"))
            {
                Ispass = false;
                Error += "رمز عبور باید شامل حداقل یک حرف بزرگ و حداقل یک حرف کوچک و حداقل یک عدد و تعداد کارکتر های ان حداکثر 32 و حداقل 8 کاراکتر باشد " + "\n";
            }
            if (Error != "")
            {
            matinLabel:
                MessageBoxResult a = MessageBox.Show(Error + "ردیفه؟", "UNVALID INPUT", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (a == MessageBoxResult.Yes) { return; }
                if (a == MessageBoxResult.No) { goto matinLabel; }
            }
            else
            {
                int i = 0;
                foreach (Restaurant r in restaurants)
                {
                    if (r.UserName == username)
                    {
                        Bflag = true;
                        break;
                    }
                    i++;
                }
                if (!Bflag)
                {
                    MessageBox.Show("UnKnown UserName", "UNVALID INPUT", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    return;
                }
                restaurants[i].PassWord = pass;
                MessageBox.Show("Done!", "GoodNews", MessageBoxButton.OK, MessageBoxImage.Information);
                Must_OFF = false;

                this.Close();
                File.WriteAllText(MainWindow.Get_Dir_ALL_RESTAURANT_json(), JsonConvert.SerializeObject(restaurants,Formatting.Indented));
            }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveBeforeClose();
          if(Must_OFF)  Application.Current.Shutdown();

        }

        private List<Restaurant>? GetAllRes(string path)
        {
            return JsonConvert.DeserializeObject<List<Restaurant>>(File.ReadAllText(path));
        }
        private List<User>? GetAllUser(string path)
        {
            return JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(path));
        }
        private List<Admin>? GetAllAdmin(string path)
        {
            return JsonConvert.DeserializeObject<List<Admin>>(File.ReadAllText(path));
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            SaveBeforeClose();
            AdminPage BACK = new AdminPage(admin);
            BACK.Show();
            Must_OFF = false;

            this.Close();

        }
        private void SaveBeforeClose()
        {

        }
    }
}
