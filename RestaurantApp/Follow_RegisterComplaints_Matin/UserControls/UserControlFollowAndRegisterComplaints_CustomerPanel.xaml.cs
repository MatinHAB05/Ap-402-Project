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

namespace RestaurantApp.Follow_RegisterComplaints_Matin.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlFollowAndRegisterComplaints_CustomerPanel.xaml
    /// </summary>
    public partial class UserControlFollowAndRegisterComplaints_CustomerPanel : UserControl
    {
        public string LabelContent {  get; set; }
        public int HeightTxtBox {  get; set; }
        public UserControlFollowAndRegisterComplaints_CustomerPanel()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
