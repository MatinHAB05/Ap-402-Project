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

namespace MainProject.ReviewComplaints_Matin
{
    /// <summary>
    /// Interaction logic for ReviewUnreviewedComplaints_Page.xaml
    /// </summary>
    public partial class ReviewComplaints_Page : Window
    {
        public ObservableCollection<complaints_User_FORNOW> comes { get; set; }

        public Admin admin {  get; set; }
        public class complaints_User_FORNOW
        {
            public string name { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Title { get; set; }
            public string NameRes { get; set; }
            public bool IsChecked { get; set; }
            public string response {  get; set; }
            public int ComplaintID {  get; set; }
            public complaints_User_FORNOW(string name, string lastname, string username, string title, string nameRes, bool isChecked, string response, int complaintID)
            {
                this.name = name;
                this.Title = title;
                this.LastName = lastname;
                this.IsChecked = isChecked;
                this.NameRes = nameRes;
                this.UserName = username;
                this.response = response;
                ComplaintID = complaintID;
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
                demo.response = this.response;
                demo.ComplaintID = this.ComplaintID;
                return demo;
            }
        }
        public ReviewComplaints_Page(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            this.DataContext = this;
            //For Now 
            List<Complaint> complaints = JsonConvert.DeserializeObject<List<Complaint>>(File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Complaint\All_Complaints.json"));

            comes = new ObservableCollection<complaints_User_FORNOW>
                (
                complaints.Select(com => new complaints_User_FORNOW
                {
                    IsChecked = com.IsChecked,
                    Title = com.ComplaintTitile,
                    name = User.GetFIRSTNAMEfromjson(com.User_UserName),
                    LastName = User.GetLASTNAMEfromjson(com.User_UserName),
                    UserName = com.User_UserName,
                    NameRes = Restaurant.GetFromUserName(com.RestaurantUserName).RestaurantName , 
                    response = com.Response , 
                    ComplaintID = com.ComplainID
                }
                ).ToList());
            DataGridResault.ItemsSource = comes;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveBeforeClose();
            Application.Current.Shutdown();

        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            SaveBeforeClose();
            AdminPage back =new AdminPage(admin);
            back.Show();
            this.Close();

        }
        private void SaveBeforeClose()
        {

        }
    }
}
