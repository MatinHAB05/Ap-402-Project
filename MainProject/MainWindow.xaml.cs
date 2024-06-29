using MainProject.LoginForm_Matin;
using MainProject.ReviewAndEditUnreviewedComplaints_Matin;
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

            LoginPage searchPageForm = new LoginPage();
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