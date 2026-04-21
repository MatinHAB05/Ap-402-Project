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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestaurantApp.SignInPage_Matin.Usercontrol
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public string IMGSource {  get; set; }
        public int XWidth {  get; set; }
        public UserControl1()
        {
            InitializeComponent();
            this.DataContext = this;

        }
    }
}
            //< Image Source = "{Binding IMGSource}" />
