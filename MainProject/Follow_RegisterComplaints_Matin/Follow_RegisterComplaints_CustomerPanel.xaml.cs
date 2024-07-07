using MainProject.CustomerMainPage_Parham.CustomerMainPage;
using MainProject.Public_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace MainProject.Follow_RegisterComplaints_Matin
{
    /// <summary>
    /// Interaction logic for Follow_RegisterComplaints_CustomerPanel.xaml
    /// </summary>
    public partial class Follow_RegisterComplaints_CustomerPanel : Window, INotifyCollectionChanged
    {
        internal User CurrentUser { get; set; }
        public CustomerMainPage PreviousPage { get; set; }
        private ObservableCollection<complaints_User_FORNOW> _complaints_CurrentUser;
        public List<Complaint> ALLLLL { get; set; }
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public ObservableCollection<complaints_User_FORNOW> complaints_CurrentUser{ get{ return _complaints_CurrentUser; } set { _complaints_CurrentUser = value; } }
        public List<complaints_User_FORNOW> NewComplaints { get; set; }
        public class complaints_User_FORNOW
        {
            public string UserName { get; set; }
            public string Title { get; set; }
            public string NameRes { get; set; }
            public bool IsChecked { get; set; }
            public string Response { get; set; }
           
            public complaints_User_FORNOW (string username, string title, string nameRes, bool isChecked, string response)
            {
                this.Title = title;
                this.IsChecked = isChecked;
                this.NameRes = nameRes;
                this.UserName = username;
                this.Response = response;
            }
        }
        public Follow_RegisterComplaints_CustomerPanel(CustomerMainPage prepage)
        {
            InitializeComponent();
            this.PreviousPage = prepage;
            CurrentUser = prepage.CurrentUser;

            string jsonCom = File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Complaint\All_Complaints.json");
            List<Complaint> Demo = JsonConvert.DeserializeObject<List<Complaint>>(jsonCom);
            Demo = (Demo.Where(cm => cm.User_UserName == CurrentUser.UserName && cm!=null)).ToList();
            complaints_CurrentUser = new ObservableCollection<complaints_User_FORNOW>(Demo.Select(c => new complaints_User_FORNOW(c.User_UserName, c.ComplaintTitile, Restaurant.GetFromUserName(c.RestaurantUserName.Trim()).RestaurantName, c.IsChecked, c.Response)).ToList());
            //complaints_CurrentUser =

            //EditBut.Visibility = Visibility.Visible;
            //SaveBut.Visibility = Visibility.Hidden;
            //For Now 

            DataGridResault.ItemsSource = complaints_CurrentUser;

             this.DataContext = this;

        }

        private void AddComplaints(object sender, RoutedEventArgs e)
        {
            if(Restaurant.GetFromname(user1.txtBox.Text.Trim()) == null)
            {
                MessageBox.Show("UnKnown Restaurants Name !");
                return;
            }
            complaints_User_FORNOW X = new complaints_User_FORNOW(CurrentUser.UserName, user2.txtBox.Text.Trim(), user1.txtBox.Text.Trim(), false, "");
            complaints_CurrentUser.Add(X);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
            MessageBox.Show("Added","Info",MessageBoxButton.OK, MessageBoxImage.Information);

            string jsonCom = File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Complaint\All_Complaints.json");
            List<Complaint> Demo = JsonConvert.DeserializeObject<List<Complaint>>(jsonCom);
            Complaint Y = new Complaint();
            Y.ComplainText=user3.txtBox.Text;
            Y.Response = "";
            Y.IsChecked = false;
            Y.RestaurantUserName = Restaurant.GetFromname( X.NameRes).UserName;
            Y.User_UserName = X.UserName;
            Y.ComplaintTitile = X.Title;
            Y.User_UserName=X.UserName;
            Y.ComplainID = Complaint.ComPlaintIDGenrator();
            Demo.Add(Y);
            File.WriteAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Complaint\All_Complaints.json",
                JsonConvert.SerializeObject(Demo,Formatting.Indented));

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            user1.txtBox.VerticalContentAlignment = VerticalAlignment.Center;
            user2.txtBox.VerticalContentAlignment = VerticalAlignment.Center;
            user1.txtBox.MaxLength = 68;
            user2.txtBox.MaxLength = 68;

            user1.txtBox.HorizontalContentAlignment = HorizontalAlignment.Left;
            user2.txtBox.HorizontalContentAlignment = HorizontalAlignment.Left;

            user3.txtBox.VerticalContentAlignment = VerticalAlignment.Top;
            user3.txtBox.HorizontalContentAlignment = HorizontalAlignment.Left;
            user3.txtBox.TextWrapping = TextWrapping.Wrap;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveBeforeClose();

        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            SaveBeforeClose();
            CustomerMainPage back = new CustomerMainPage(CurrentUser);
            back.Show();
            this.Close();

        }
        private void SaveBeforeClose()
        {

        }

        //private void EditEvent(object sender, RoutedEventArgs e)
        //{
        //    ColResponse.IsReadOnly = false;
        //    //MessageBox.Show("Edit Method is ON");

        //    EditBut.Visibility = Visibility.Hidden;
        //    SaveBut.Visibility = Visibility.Visible;

        //}
        //private void SaveEvent(object sender, RoutedEventArgs e)
        //{
        //    ColResponse.IsReadOnly = true;
        //    //MessageBox.Show("Save Method is ON");

        //    //Saved the Edits in Logic Code!!!


        //    MessageBox.Show("Saved!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        //    EditBut.Visibility = Visibility.Visible;
        //    SaveBut.Visibility = Visibility.Hidden;

        //}
    }
}
