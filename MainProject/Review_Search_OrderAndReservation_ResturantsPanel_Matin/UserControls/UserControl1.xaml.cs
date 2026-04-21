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

namespace MainProject.Review_Search_OrderAndReservation_ResturantsPanel_Matin.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public int IsClicked { get; set; }
        public UserControl1()
        {
            InitializeComponent();
            IsClicked = 0;
        }
        //private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    MessageBox.Show(IsClicked.ToString());
        //    if (IsClicked == 1) { }
        //}



        private void txtBoxSerach_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txtBoxSerach.Background = new SolidColorBrush(Colors.WhiteSmoke);
            imgD.Source = new BitmapImage(new Uri("\\Review_Search_OrderAndReservation_ResturantsPanel_Matin\\Images\\s2.jpg", UriKind.Relative));
            IsClicked = 1;
            //MessageBox.Show("TXT");
        }
    }
}
