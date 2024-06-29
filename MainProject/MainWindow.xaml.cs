
using MainProject.ReviewComplaints_Matin;
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

            ReviewComplaints_Page searchPageForm = new ReviewComplaints_Page();
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