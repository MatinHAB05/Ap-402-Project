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

namespace MainProject.SignInPage_Matin
{
    /// <summary>
    /// Interaction logic for SignInForm.xaml
    /// </summary>
    public partial class SignInForm : Window
    {
        public SignInForm()
        {
            InitializeComponent();
            //mamad.Width = 200;
            mamad.ImageVAr.Width = 38;
            //mamad.RecaVar.Width = 60;
            mamad.txtBox.Width = 176;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
