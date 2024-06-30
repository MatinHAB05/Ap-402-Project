
using MainProject.Follow_RegisterComplaints_Matin;
using MainProject.LoginForm_Matin;
using MainProject.OrderHistoryPage_Matin;
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

            Follow_RegisterComplaints_CustomerPanel searchPageForm = new Follow_RegisterComplaints_CustomerPanel();
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