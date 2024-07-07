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
using MainProject.Public_Classes;
using MainProject.AddRestunts_AdminPanel_Matin;
using MainProject.Search_Restuant_PageADMIN_Matin;
using MainProject.Search_complaints_PageADMIN_Matin;
using MainProject.ReviewAndEditUnreviewedComplaints_Matin;
using MainProject.ReviewComplaints_Matin;
using MainProject.ReviewUNREAD_AdminPanel_Matin;
using MainProject.LoginForm_Matin;

namespace MainProject.AdminPage_Parham.AdminPage
{
    public partial class AdminPage : Window
    {
        public Admin admin {  get; set; }
        internal AdminPage(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
        }
        private void Restaurant_Registration_Click(object sender, RoutedEventArgs e)
        {
            AddRestunts_AdminPanel_Page addRestunts_Admin = new AddRestunts_AdminPanel_Page(this.admin);
            addRestunts_Admin.Show();
            this.Close();
        }
        private void Search_ON_Restaurants_Click(object sender, RoutedEventArgs e)
        {
            Search_Res_AdminPageForm search_Res_AdminPageForm = new Search_Res_AdminPageForm(this.admin);
            search_Res_AdminPageForm.Show();
            this.Close();
        }
        private void Search_ON_Complaints_Click(object sender, RoutedEventArgs e)
        {
            Search_complaints_AdminPageForm search_Complaints_Admin = new Search_complaints_AdminPageForm(this.admin);
            search_Complaints_Admin.Show();
            this.Close();
        }
        private void Last_Unread_Complaints_Click(object sender, RoutedEventArgs e)
        {
            ReviewUNREAD_AdminPanel UnreviewedComplaints_Page = new ReviewUNREAD_AdminPanel(this.admin);
            UnreviewedComplaints_Page.Show();
            this.Close();
        }
        private void Answer_Last_Unread_Complaints_Click(object sender, RoutedEventArgs e)
        {
            ReviewAndEditUnreviewedComplaints_Page reviewAndEditUnreviewedComplaints_Page = new ReviewAndEditUnreviewedComplaints_Page(this.admin);
            reviewAndEditUnreviewedComplaints_Page.Show();
            this.Close();
        }
        private void All_Complaints_Click(Object sender, RoutedEventArgs e)
        {
            ReviewComplaints_Page reviewComplaints = new ReviewComplaints_Page(this.admin);
            reviewComplaints.Show();
            this.Close();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            SaveBeforeClose();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();    
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveBeforeClose();
            Application.Current.Shutdown();

        }

        private void SaveBeforeClose()
        {

        }
    }
}
