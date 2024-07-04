using MainProject.AdminPage_Parham.AdminPage;
using MainProject.Public_Classes;
using System;
using System.Collections.Generic;
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
        public Admin admin {  get; set; }
        public class complaints_User_FORNOW
        {
            public string name { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Title { get; set; }
            public string NameRes { get; set; }
            public bool IsChecked { get; set; }
            public complaints_User_FORNOW(string name, string lastname, string username, string title, string nameRes, bool isChecked)
            {
                this.name = name;
                this.Title = title;
                this.LastName = lastname;
                this.IsChecked = isChecked;
                this.NameRes = nameRes;
                this.UserName = username;
            }
        }
        public ReviewComplaints_Page(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            this.DataContext = this;
            //For Now 
            List<complaints_User_FORNOW> demo = new List<complaints_User_FORNOW>
            {
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true)

            };
            DataGridResault.ItemsSource = demo;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AdminPage Pre = new AdminPage(admin);
            Pre.Show();
        }
    }
}
