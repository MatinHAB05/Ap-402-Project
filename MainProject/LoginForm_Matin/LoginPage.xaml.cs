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

namespace MainProject.LoginForm_Matin
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Check the value 
            //PassWordBox.textBoxname.Text ...
            //if Undifinded Username or PassWord
            PassWordBox.TextBolckTEXT.Text = "Error";
            UserNameBox.TextBolckTEXT.Text = "Error2";
            MessageBox.Show("Hint to edit the Bad Inputs","This is Caption",MessageBoxButton.OK,MessageBoxImage.Error);

        }
    }
}
