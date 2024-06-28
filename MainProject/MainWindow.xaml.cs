using MainProject.LoginForm_Matin;
using MainProject.Search_complaints_PageADMIN_Matin;
using MainProject.Search_Restuant_PageADMIN_Matin;
using MainProject.SetPassWordPage_Matin;
using MainProject.SignInPage_Matin;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
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

            Search_complaints_AdminPageForm searchPageForm = new Search_complaints_AdminPageForm();
            searchPageForm.Show();
            this.Close();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //LoginPage loginPageDemo = new LoginPage();
            //loginPageDemo.Show();
            //this.Close();
            SetPassWordForm setPassWordForm = new SetPassWordForm();
            setPassWordForm.Show();
            this.Close();

        }
    }
}