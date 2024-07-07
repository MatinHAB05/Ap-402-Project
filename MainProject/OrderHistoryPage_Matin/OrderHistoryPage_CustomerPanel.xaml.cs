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
using static MainProject.Search_complaints_PageADMIN_Matin.Search_complaints_AdminPageForm;

namespace MainProject.OrderHistoryPage_Matin
{
    /// <summary>
    /// Interaction logic for ReviewUnreviewedComplaints_Page.xaml
    /// </summary>
    public partial class OrderHistoryPage_CustomerPanel : Window
    {
        bool Must_OFF;

        public ObservableCollection<OrderHistoryClass_FORNOW> oriori;
        public ObservableCollection<OrderHistoryClass_FORNOW> OLD;
        public List<FoodRequest> foodRequests;

        public User CurrentUser { get; set; }


        public class OrderHistoryClass_FORNOW
        {
            public string ResturauantName {  get; set; }
            public string FullCustomerName { get; set; }
            public string User_UserName {  get; set; }
            public int ReqID {  get; set; }
            public RequestType RequestType { get; set; }
            public string ReqRATE {  get; set; }
            public int FoodID {  get; set; }
            public string FoodName {  get; set; }
            public double price {  get; set; }
            public string Content {  get; set; }

            public OrderHistoryClass_FORNOW() { }
            public OrderHistoryClass_FORNOW cClone()
            {
                OrderHistoryClass_FORNOW dem = new OrderHistoryClass_FORNOW();
                dem.ReqID = ReqID;
                dem.ReqRATE = ReqRATE;
                dem.FullCustomerName = FullCustomerName;
                dem.User_UserName = User_UserName;
                dem.FoodName = FoodName;
                dem.FoodID = FoodID;
                dem.price= price;
                dem.RequestType = RequestType;
                dem.ResturauantName = ResturauantName;
                return dem;
            }
        }

        public OrderHistoryPage_CustomerPanel(CustomerMainPage prepage)
        {
            InitializeComponent();
            Must_OFF = true;
            CurrentUser = prepage.CurrentUser;
            EditBut.Visibility = Visibility.Visible;
            SaveBut.Visibility = Visibility.Hidden;
            ResetBut.Visibility = Visibility.Hidden;
            int bro = 0;
            foodRequests = JsonConvert.DeserializeObject<List<FoodRequest>>(File.ReadAllText(MainWindow.Get_Dir_ALL_FOOD_REQUEST_json()));

            oriori = new ObservableCollection<OrderHistoryClass_FORNOW>(foodRequests.Select(fr => { /*MessageBox.Show(bro.ToString());bro++;*/
                return new OrderHistoryClass_FORNOW
            {
                ResturauantName = Restaurant.GetFromUserName(fr.RestaurantUserName).RestaurantName,
                FullCustomerName = User.GetFIRSTNAMEfromjson(fr.User_UserName) + User.GetLASTNAMEfromjson(fr.User_UserName),
                User_UserName = fr.User_UserName,
                ReqID = fr.RequestID,
                RequestType = fr.RequestType,
                FoodID = fr.FoodID,
                FoodName = Restaurant.Get_Food_FromFoodID(fr.FoodID, Restaurant.GetFromUserName(fr.RestaurantUserName)).Name,
                price = Restaurant.Get_Food_FromFoodID(fr.FoodID, Restaurant.GetFromUserName(fr.RestaurantUserName)).price,
                Content = "",
                ReqRATE = ""
            };
            }
            )
                .ToList());
            int i = 0;
            foreach(OrderHistoryClass_FORNOW o in oriori)
            {
                Reception_Point? rec = Reception_Point.GetFromjson(o.ReqID);
                if ( rec!= null)
                {
                    if (rec.Point == null) oriori[i].ReqRATE = "";
                    else { oriori[i].ReqRATE = rec.Point.ToString(); }
                }
                i++;
            }

            OLD = new ObservableCollection<OrderHistoryClass_FORNOW>();
            foreach(OrderHistoryClass_FORNOW a in oriori)
            {
                OLD.Add(a.cClone());
            }
            DataGridResault.ItemsSource = oriori.Where(ori=>ori.User_UserName==CurrentUser.UserName).ToList();
            this.DataContext = this;

        }

        private void EditEvent(object sender, RoutedEventArgs e)
        {
            ColReqRATE.IsReadOnly = false;
            ColComment.IsReadOnly = false;
            //MessageBox.Show("Edit Method is ON");

            EditBut.Visibility = Visibility.Hidden;
            SaveBut.Visibility = Visibility.Visible;
            ResetBut.Visibility = Visibility.Visible;

        }
        private void SaveEvent(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show((oriori[1].ReqRATE==null).ToString());
            //Save comment
            List<ReceptionComment> list = JsonConvert.DeserializeObject<List<ReceptionComment>>(File.ReadAllText(MainWindow.Get_Dir_ALL_RECEPTION_COMMENT_json()));
            int i = 0;
            foreach (OrderHistoryClass_FORNOW com in oriori)
            {
                if (com.Content.Trim() != "")
                {
                    int flag;
                    int random;
                    do
                    {
                        flag = 0;
                        random = (new Random()).Next(100, 1000000);
                        foreach (ReceptionComment rc in list)
                        {
                            if (rc.CommentID == random)
                            {
                                flag = 1; break;
                            }
                        }
                    } while (flag == 1);
                    list.Add(new ReceptionComment($"Complaint from *{CurrentUser.UserName}*", oriori[i].Content, random, CurrentUser.UserName, oriori[i].ReqID));
                }
                i++;

            }
            File.WriteAllText(MainWindow.Get_Dir_ALL_RECEPTION_COMMENT_json(),JsonConvert.SerializeObject(list,Formatting.Indented));
            //Save comment [[[end]]]

            //Save Point
            int flagVALID = 1;
            List<OrderHistoryClass_FORNOW> ZZ = oriori.Where(OR => OR.User_UserName == CurrentUser.UserName).ToList();
            List<OrderHistoryClass_FORNOW> Z = OLD.Where(OR => OR.User_UserName == CurrentUser.UserName).ToList();

            foreach (OrderHistoryClass_FORNOW or in ZZ)
            {
                try
                {
                    double testDemo = double.Parse(or.ReqRATE.Trim());
                }
                catch (Exception ex) { MessageBox.Show("You Must Enter Just Number[Request Rate]!", "Error", MessageBoxButton.OK, MessageBoxImage.Error); return; }
                if (or.ReqRATE.Trim() == "")
                {
                    continue;
                }
                else if(double.Parse(or.ReqRATE)>10 || double.Parse(or.ReqRATE) < 0)
                {
                    flagVALID--;
                    break;
                }
            }
            if(flagVALID == 1)
            {
                List<OrderHistoryClass_FORNOW> Filter = new List<OrderHistoryClass_FORNOW>();
                for (int q = 0; q < ZZ.Count; q++)
                {
                    OrderHistoryClass_FORNOW test=new OrderHistoryClass_FORNOW();
                    if (ZZ[q].ReqRATE.Trim()==Z[q].ReqRATE.Trim()) { Filter.Add(ZZ[q]); }//add
                    else if (ZZ[q].ReqRATE.Trim() != "" && Z[q].ReqRATE.Trim() == "") { Filter.Add(ZZ[q]); }//Add
                    else if (ZZ[q].ReqRATE.Trim() == "" && Z[q].ReqRATE.Trim() != "") {/*Igonre!*/ }//Remove
                    else if (ZZ[q].ReqRATE.Trim() != Z[q].ReqRATE.Trim()) { test = ZZ[q];test.ReqRATE = ZZ[q].ReqRATE.Trim();  Filter.Add(test); }//Edit
                 }
                List<Reception_Point> SaveList = Filter.Select(f => new Reception_Point
                { RequestID=f.ReqID , Point=IfEmptyReturenNull(f.ReqRATE.Trim()), UserName=f.User_UserName,UserID=0 }
                ).ToList();
                List<Reception_Point> RECpoint = JsonConvert.DeserializeObject<List<Reception_Point>>(File.ReadAllText(MainWindow.Get_Dir_ALL_RECEPTION_POINT_json())).
                                                    Where(r => r.UserName != CurrentUser.UserName).ToList();
                SaveList.AddRange(RECpoint);
                File.WriteAllText(MainWindow.Get_Dir_ALL_RECEPTION_POINT_json(),JsonConvert.SerializeObject(SaveList,Formatting.Indented));
            }
            else
            {
                MessageBox.Show("Point Must BE in [0,10]!", "Warring", MessageBoxButton.OK, MessageBoxImage.Stop);return;
            }
            MessageBox.Show("Saved!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            OLD.Clear();
            for (int a=0; a<oriori.Count;a++)
            {
                oriori[a].Content = "";
                OLD.Add(oriori[a].cClone());
            }
            DataGridResault.ItemsSource = oriori.Where(OR => OR.User_UserName == CurrentUser.UserName).ToList();
            //MessageBox.Show(Orders[2].Rate.ToString());


            //MessageBox.Show(oriori[1].ReqRATE.ToString());
            ColReqRATE.IsReadOnly = true;
            ColComment.IsReadOnly = true;
            EditBut.Visibility = Visibility.Visible;
            SaveBut.Visibility = Visibility.Hidden;
            ResetBut.Visibility = Visibility.Hidden;
        }

        private void ResetEvent(object sender, RoutedEventArgs e)
        {
            oriori.Clear();
            foreach (OrderHistoryClass_FORNOW a in OLD)
            {
                oriori.Add(a.cClone());
            }
            DataGridResault.ItemsSource = oriori.Where(ori => ori.User_UserName == CurrentUser.UserName).ToList();


            MessageBox.Show("Reset!", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveBeforeClose();
          if(Must_OFF)  Application.Current.Shutdown();

        }

        private double? IfEmptyReturenNull(string a)
        {
            if(a.Trim()=="")return null;
            return double.Parse(a.Trim());
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            SaveBeforeClose();
            CustomerMainPage back = new CustomerMainPage(CurrentUser);
            back.Show();
            Must_OFF = false;
            this.Close();

        }
        private void SaveBeforeClose()
        {

        }
    }
}
