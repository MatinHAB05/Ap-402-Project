using MainProject.CustomerMainPage_Parham.CustomerMainPage;
using MainProject.Public_Classes;
using Newtonsoft.Json;
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

namespace MainProject.OrderHistoryPage_Matin
{
    /// <summary>
    /// Interaction logic for ReviewUnreviewedComplaints_Page.xaml
    /// </summary>
    public partial class OrderHistoryPage_CustomerPanel : Window
    {

        internal User CurrentUser { get; set; }
        public CustomerMainPage PreviousPage { get; set; }
        public List<OrderHistoryClass_Demo> Orders { get; set; }

        public class OrderHistoryClass_Demo
        {
            FoodRequest FoodRequest { get; set; }
            double Rate {  get; set; }
            internal OrderHistoryClass_Demo(FoodRequest foodRequest,double rate)
            {
                FoodRequest = foodRequest;
                Rate = rate;
            }
        }

        internal OrderHistoryPage_CustomerPanel(CustomerMainPage prepage)
        {
            InitializeComponent();
            this.DataContext = this;
            this.PreviousPage = prepage;
            CurrentUser = prepage.CurrentUser;

            EditBut.Visibility = Visibility.Visible;
            SaveBut.Visibility = Visibility.Hidden;
            
            Orders=GetOrderHistoryClasses(CurrentUser);
            DataGridResault.ItemsSource = Orders;

        }

        private void EditEvent(object sender, RoutedEventArgs e)
        {
            ColRate.IsReadOnly = false;
            ColComment.IsReadOnly = false;

            //MessageBox.Show("Edit Method is ON");

            EditBut.Visibility = Visibility.Hidden;
            SaveBut.Visibility = Visibility.Visible;

        }
        private void SaveEvent(object sender, RoutedEventArgs e)
        {
            ColRate.IsReadOnly = true;
            ColComment.IsReadOnly = true;
            //MessageBox.Show("Save Method is ON");

            //Saved the Edits in Logic Code!!!


            MessageBox.Show("Saved!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            EditBut.Visibility = Visibility.Visible;
            SaveBut.Visibility = Visibility.Hidden;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CustomerMainPage customerMainPage = new CustomerMainPage(CurrentUser);
            customerMainPage.Show();
        }

        private List<FoodRequest> GetFoodRequests_From_Json_For_CurrentUser(User currentUser, string path)
        {
            string jsonRead = File.ReadAllText(path);
            List<FoodRequest>? AllFoods = JsonConvert.DeserializeObject<List<FoodRequest>>(jsonRead);
            List<FoodRequest>? XfoodRequest = AllFoods.Where(fr => fr.User.UserName== currentUser.UserName).ToList();
            return XfoodRequest;
        }
        private List<Food_Point> GetFoodPoints_From_Json_For_CurrentUser(User currentUser, string path)
        {
            string jsonRead = File.ReadAllText(path);
            List<Food_Point>? AllFoodsPoint = JsonConvert.DeserializeObject<List<Food_Point>>(jsonRead);
            List<Food_Point>? XfoodPoint = AllFoodsPoint.Where(fp => fp.UserName == currentUser.UserName).ToList();
            return XfoodPoint;
        }

        private List<OrderHistoryClass_Demo> GetOrderHistoryClasses(User CurrenUser)
        {
            List<FoodRequest> foodRequests = GetFoodRequests_From_Json_For_CurrentUser(CurrentUser, @"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\MainProject\JsonFiles\FoodRequest\All_FoodRequest.json");
            List<Food_Point> food_Points = GetFoodPoints_From_Json_For_CurrentUser(CurrentUser, @"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\MainProject\JsonFiles\Points\All_Points.json");
            List<OrderHistoryClass_Demo> DEMO = foodRequests.Join(food_Points,fr=>fr.FoodClass.FoodID,fp=>fp.FoodID,(fr,fp)=>new OrderHistoryClass_Demo(fr,fp.Point)).ToList();
            return DEMO;
        }
    }
}
