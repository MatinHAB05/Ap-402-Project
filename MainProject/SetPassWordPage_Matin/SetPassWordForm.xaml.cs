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

namespace MainProject.SetPassWordPage_Matin
{
    /// <summary>
    /// Interaction logic for SetPassWordForm.xaml
    /// </summary>
    public partial class SetPassWordForm : Window
    {
        public string Password { get; set; }
        public string Confrim_Password { get; set; }
        public string Email_Code {  get; set; }
        public SetPassWordForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }


    }
}
