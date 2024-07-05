using MailKit.Search;
using MainProject.AdminPage_Parham.AdminPage;
using MainProject.Public_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MainProject.ReviewAndEditUnreviewedComplaints_Matin
{
    /// <summary>
    /// Interaction logic for ReviewUnreviewedComplaints_Page.xaml
    /// </summary>
    public partial class ReviewAndEditUnreviewedComplaints_Page : Window
    {
        public Admin admin { get; set; }
        public List<complaints_User_FORNOW> comes { get; set; }

        public List<complaints_User_FORNOW> old { get; set; }
        public List<Complaint> all_complaints { get; set; }

        public class complaints_User_FORNOW
        {
            public string name { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Title { get; set; }
            public string NameRes { get; set; }
            public bool IsChecked { get; set; }
            public string Response {  get; set; }
            public int ComplaintID {  get; set; }
            public string ComplaintText {  get; set; }
            public complaints_User_FORNOW(string name, string lastname, string username, string title, string nameRes, bool isChecked, string response, int complaintID, string complaintText)
            {
                this.name = name;
                this.Title = title;
                this.LastName = lastname;
                this.IsChecked = isChecked;
                this.NameRes = nameRes;
                this.UserName = username;
                this.Response = response;
                this.ComplaintID = complaintID;
                this.ComplaintText = complaintText;
            }
            public complaints_User_FORNOW() { }
            public complaints_User_FORNOW cClone()
            {
                complaints_User_FORNOW demo = new complaints_User_FORNOW();
                demo.name = this.name;
                demo.LastName = this.LastName;
                demo.UserName = this.UserName;
                demo.Title = this.Title;
                demo.NameRes = this.NameRes;
                demo.IsChecked = this.IsChecked;
                demo.Response = this.Response;
                demo.ComplaintID = this.ComplaintID;
                demo.ComplaintText = this.ComplaintText;

                return demo;
            }
        }
        public ReviewAndEditUnreviewedComplaints_Page(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            this.DataContext = this;
            EditBut.Visibility = Visibility.Visible;
            SaveBut.Visibility = Visibility.Hidden;
            ResetBut.Visibility = Visibility.Hidden;
            //For Now 
            all_complaints = JsonConvert.DeserializeObject<List<Complaint>>(File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Complaint\All_Complaints.json"));
            comes = all_complaints.Select(com => new complaints_User_FORNOW
                         {
                             IsChecked = com.IsChecked,
                             Title = com.ComplaintTitile,
                             name = User.GetFIRSTNAMEfromjson(com.User_UserName),
                             LastName = User.GetLASTNAMEfromjson(com.User_UserName),
                             UserName = com.User_UserName,
                             NameRes = Restaurant.GetFromUserName(com.RestaurantUserName).RestaurantName,
                             Response = com.Response,
                             ComplaintID = com.ComplainID,
                             ComplaintText=com.ComplainText

                         }
                         ).ToList();            //DataGridResault.ItemsSource = demo;



            old = new List<complaints_User_FORNOW>();
            foreach (complaints_User_FORNOW a in comes) {  old.Add(a.cClone()); }

            //****
            DataGridResault.ItemsSource = comes.Where(cm=>cm.IsChecked==false).ToList() ; ;
        }

        private void EditEvent(object sender, RoutedEventArgs e)
        {
            ColResponse.IsReadOnly = false;
            //MessageBox.Show("Edit Method is ON");

            EditBut.Visibility = Visibility.Hidden;
            SaveBut.Visibility = Visibility.Visible;
            ResetBut.Visibility = Visibility.Visible;

        }
        private void SaveEvent(object sender, RoutedEventArgs e)
        {
            ColResponse.IsReadOnly = true;
            foreach(complaints_User_FORNOW c in comes)
            {
                if(c.IsChecked == false && c.Response.Trim() != "")
                {
                    c.IsChecked= true;
                } 
            }
            //Savein Json!!!;
            List<Complaint> SaveList = comes.Select(cm => new Complaint
            {
                ComplainID=cm.ComplaintID,
                ComplaintTitile=cm.Title,
                User_UserName=cm.UserName,
                RestaurantUserName=Restaurant.GetFromname(cm.NameRes).UserName,
                IsChecked=cm.IsChecked,
                Response=cm.Response,
                ComplainText=cm.ComplaintText
            }).ToList();

            File.WriteAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Complaint\All_Complaints.json",
                JsonConvert.SerializeObject(SaveList, Formatting.Indented));
            //Saved IN grid!!!
            old.Clear();
            foreach (complaints_User_FORNOW a in comes) { old.Add(a.cClone()); }
            DataGridResault.ItemsSource = comes.Where(cm => cm.IsChecked == false).ToList(); ;


            MessageBox.Show("Saved!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            EditBut.Visibility = Visibility.Visible;
            SaveBut.Visibility = Visibility.Hidden;
            ResetBut.Visibility = Visibility.Hidden;


        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AdminPage Pre = new AdminPage(admin);
            Pre.Show();
        }
        private void ResetEvent(object sender, RoutedEventArgs e)
        {
            comes.Clear();
            foreach (complaints_User_FORNOW a in old) {  comes.Add(a.cClone()); }
            DataGridResault.ItemsSource = comes.Where(cm => cm.IsChecked == false).ToList(); ;


        }
    }
}
