
using MainProject.Follow_RegisterComplaints_Matin;
using MainProject.LoginForm_Matin;
using MainProject.OrderHistoryPage_Matin;
using MainProject.Review_Search_OrderAndReservation_ResturantsPanel_Matin;
using System.Windows;
using System.Windows.Shapes;

namespace MainProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Review_Search_OrderAndReservation_ResturantsPage searchPageForm = new Review_Search_OrderAndReservation_ResturantsPage();
            searchPageForm.Show();
            this.Close();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //LoginPage loginPageDemo = new LoginPage();
            //loginPageDemo.Show();
            //this.Close();
            //SetPassWordForm setPassWordForm = new SetPassWordForm();
            //setPassWordForm.Show();
            //this.Close();

        }
    }
}