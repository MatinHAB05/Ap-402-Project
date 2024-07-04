using MainProject.CustomerMainPage_Parham.CustomerMainPage;
using MainProject.Public_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
    public partial class OrderHistoryPage_CustomerPanel : Window , INotifyCollectionChanged
    {

        public User CurrentUser { get; set; }
        public CustomerMainPage PreviousPage { get; set; }

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public BindingList<OrderHistoryClass_Demo> Orders { get; set; }
        public BindingList<OrderHistoryClass_Demo> OldOrders { get; set; }
        public class OrderHistoryClass_Demo
        {
            public FoodRequest FoodRequest { get; set; }
            public double Rate {  get; set; }
            public List<ReceptionComment> NewComments { get; set; }
            public string NameCur {  get; set; }
            public string LastNameCur {  get; set; }
            public OrderHistoryClass_Demo() { }
            public OrderHistoryClass_Demo(FoodRequest foodRequest,double rate,string Name , string Last)
            {
                FoodRequest = foodRequest;
                Rate = rate;
                NameCur = Name;
                LastNameCur = Last;
                NewComments = new List<ReceptionComment>();
            }
        }

        public OrderHistoryPage_CustomerPanel(CustomerMainPage prepage)
        {
            InitializeComponent();
            this.PreviousPage = prepage;
            CurrentUser = prepage.CurrentUser;
            EditBut.Visibility = Visibility.Visible;
            SaveBut.Visibility = Visibility.Hidden;
            ResetBut.Visibility = Visibility.Hidden;
            
            Orders=GetOrderHistoryClasses(CurrentUser);
            OldOrders =cClone( Orders);
            //DataGridResault.ItemsSource = Orders;
            this.DataContext = this;

        }

        private void EditEvent(object sender, RoutedEventArgs e)
        {
            ColRate.IsReadOnly = false;
            ColComment.IsReadOnly = false;

            //MessageBox.Show("Edit Method is ON");

            EditBut.Visibility = Visibility.Hidden;
            SaveBut.Visibility = Visibility.Visible;
            ResetBut.Visibility = Visibility.Visible;

        }
        private void SaveEvent(object sender, RoutedEventArgs e)
        {
            ColRate.IsReadOnly = true;
            ColComment.IsReadOnly = true;
            //MessageBox.Show("Save Method is ON");

            //Saved the Edits in Logic Code!!!


            EditBut.Visibility = Visibility.Visible;
            SaveBut.Visibility = Visibility.Hidden;
            ResetBut.Visibility = Visibility.Hidden;

            //MessageBox.Show(Orders[2].Rate.ToString());
            int flag = 0;

            foreach(var o in Orders)
            {
                if(o.Rate<0 || o.Rate > 10)
                {
                    flag++;
                    break;
                }
            }
            if(flag == 1)
            {
                //Error
                MessageBox.Show("Rate Must Be in [0,10]!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                Orders.Clear();
                foreach (var item in OldOrders)
                {
                    Orders.Add(cCloneDeep(item));
                }
            }
            else
            {
                //save in files!

                OldOrders.Clear();
                foreach (var item in Orders)
                {
                    OldOrders.Add(cCloneDeep(item));
                }
                MessageBox.Show("Saved!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

            }



        }

        private void ResetEvent(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show("Save Method is ON");

            //Saved the Edits in Logic Code!!!


            MessageBox.Show("Reset!", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            Orders.Clear();
            foreach (var item in OldOrders)
            {
                Orders.Add(cCloneDeep(item));
            }

            // به روز رسانی DataGrid برای نمایش تغییرات
            DataGridResault.ItemsSource = Orders;

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
            List<FoodRequest>? XfoodRequest = AllFoods.Where(fr => fr.User_UserName == currentUser.UserName).ToList();
            return XfoodRequest;
        }
        private List<Reception_Point> GetReceptionPoints_From_Json_For_CurrentUser(User currentUser, string path)
        {
            string jsonRead = File.ReadAllText(path);
            List<Reception_Point>? AllReceptionsPoint = JsonConvert.DeserializeObject<List<Reception_Point>>(jsonRead);
            List<Reception_Point>? XreceptionPoint = AllReceptionsPoint.Where(rp => rp.UserName == currentUser.UserName).ToList();
            return XreceptionPoint;
        }

        private BindingList<OrderHistoryClass_Demo> GetOrderHistoryClasses(User CurrenUser)
        {
            List<FoodRequest> foodRequests = GetFoodRequests_From_Json_For_CurrentUser(CurrentUser, @"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\MainProject\JsonFiles\FoodRequest\All_FoodRequest.json");
            List<Reception_Point> reception_point = GetReceptionPoints_From_Json_For_CurrentUser(CurrentUser, @"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\MainProject\JsonFiles\Points\All_ReceptionPoint.json");
            IEnumerable<OrderHistoryClass_Demo> DEMO = foodRequests.Join(reception_point, fr => fr.RequestID, rp => rp.RequestID, (fr, rp) => new OrderHistoryClass_Demo(fr, rp.Point, CurrentUser.Name, CurrentUser.LastName));
            return new BindingList<OrderHistoryClass_Demo>(DEMO.ToList());
        }
        private BindingList<OrderHistoryClass_Demo> cClone(BindingList<OrderHistoryClass_Demo> X)
        {
            BindingList<OrderHistoryClass_Demo> newCollection = new BindingList<OrderHistoryClass_Demo>();
            foreach (OrderHistoryClass_Demo item in X)
            {
                if (item != null)
                {
                    // کلون کردن عمیق برای هر آیتم
                    OrderHistoryClass_Demo clone = cCloneDeep(item);
                    newCollection.Add(clone);
                }
            }
            return newCollection;
        }

        private OrderHistoryClass_Demo cCloneDeep(OrderHistoryClass_Demo a)
        {
            // ایجاد یک شیء جدید از OrderHistoryClass_Demo
            OrderHistoryClass_Demo b = new OrderHistoryClass_Demo();

            // کپی کردن ویژگی‌های ساده
            b.Rate = a.Rate;
            b.NameCur = a.NameCur;
            b.LastNameCur= a.LastNameCur;
            // کپی کردن ویژگی‌های پیچیده (ایجاد یک شیء جدید از FoodRequest)
            if (a.FoodRequest != null)
            {
                b.FoodRequest = new FoodRequest
                {
                    RequestType = a.FoodRequest.RequestType,
                    RestaurantUserName = a.FoodRequest.RestaurantUserName,
                    FoodID = a.FoodRequest.FoodID,
                    RequestID = a.FoodRequest.RequestID,
                    User_UserName = a.FoodRequest.User_UserName

                };
            }
            if(b.NewComments != null)
            {
                b.NewComments = new List<ReceptionComment>();
                foreach (ReceptionComment ccc in b.NewComments)
                {
                    b.NewComments.Add(ccc.cCloneComment());


                }
            }
            return b;
        }

    }
}
