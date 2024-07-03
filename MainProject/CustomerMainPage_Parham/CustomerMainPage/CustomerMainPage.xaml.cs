using MainProject.ProfilePage_Parham.ProfilePage;
using MainProject.Public_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Metrics;
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
using System.Linq;
using System.Windows.Media.Animation;
using MainProject.OrderHistoryPage_Matin;
using MainProject.Follow_RegisterComplaints_Matin;

namespace MainProject.CustomerMainPage_Parham.CustomerMainPage
{
    public partial class CustomerMainPage : Window, INotifyPropertyChanged
    {
        internal User CurrentUser;
        internal List<Restaurant>? restaurants;
        internal CustomerMainPage(User user)
        {
            InitializeComponent();
            CurrentUser = user;
            //edit the details of this user!!!
            string jsonRes = File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\MainProject\JsonFiles\Restaurant\All_Restaurant.json");
            restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(jsonRes);
            SearchList.ItemsSource = restaurants;
            //SearchList.ItemsSource = names;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            TYPEstatus.Text = "";
            Nametxt.Text = "enter Name";
            Citytxt.Text = "enter City";
            Ratetxt.Text = "enter how many rating";
            XClear.Focus();
        }
        private void SearchAllFilter(object sender, RoutedEventArgs e)
        {
            ReceptionType? Filter_receptionType = null;
            string name = Nametxt.Text.Trim();
            string city = Citytxt.Text.Trim();
            double? rate = null;
            if (Ratetxt.Text == "" || Ratetxt.Text == null)
            {
                rate = 0;
            }
            else
            {
                try
                {

                    rate = Double.Parse(Ratetxt.Text);
                    if (rate < 0 || rate > 10) { throw new Exception(); }
                }
                catch (Exception ex) { MessageBox.Show("Rate Must Be [0,10] !", "Error", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            }
            if (TYPEstatus.Text == "Delivery-In") Filter_receptionType = ReceptionType.Delivery;
            else if (TYPEstatus.Text == "Dine-In") Filter_receptionType = ReceptionType.Dine_In;
            else { MessageBox.Show("UnKnown Reception Type!","Error", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            if (city == "" && name == "")
            {
                SearchList.ItemsSource = restaurants.Select(res => { res.Calculate(); return res; })
                    .Where(res => (res.Rating >= rate))
                    .ToList<Restaurant>();


            }
            else
            {
                if (name == "")
                {
                    SearchList.ItemsSource = restaurants.Select(res => { res.Calculate(); return res; })
                       .Where(res => (res.Rating >= rate) && (res.CityName == city))
                       .ToList<Restaurant>();



                }
                else if (city == "")
                {
                    SearchList.ItemsSource = restaurants.Select(res => { res.Calculate(); return res; })
                                                 .Where(res => (res.Rating >= rate) && (res.RestaurantName == city))
                                                 .ToList<Restaurant>();

                }
                else
                {
                    SearchList.ItemsSource = restaurants.Select(res => { res.Calculate(); return res; })
                             .Where(res => (res.Rating >= rate) && (res.RestaurantName == city) && (res.CityName==city) )
                             .ToList<Restaurant>();
                }
            }


        }
        private void Dine_In(object sender, RoutedEventArgs e)
        {
            TYPEstatus.Text = "Dine-In";
            TYPEstatus.FontSize = 10;

        }
        private void Delivery_In(object sender, RoutedEventArgs e)
        {
            TYPEstatus.Text = "Delivery-In";
            TYPEstatus.FontSize = 8;

        }

        private void GoProfilePage(object sender, RoutedEventArgs e)
        {
            ProfilePage profile = new ProfilePage(this);
            profile.Show();
            this.Close();
        }

        private void GotoOrderHistoy(object sender, RoutedEventArgs e)
        {
            OrderHistoryPage_CustomerPanel orderHistoryPage = new OrderHistoryPage_CustomerPanel(this);
            orderHistoryPage.Show();
            this.Close();
        }

        private void GotoFollow_up_and_register_complaints(object sender, RoutedEventArgs e)
        {
            Follow_RegisterComplaints_CustomerPanel follow_RegisterComplaints_CustomerPanel = new Follow_RegisterComplaints_CustomerPanel(this);
            follow_RegisterComplaints_CustomerPanel.Show();
            this.Close();
        }
    }
}
