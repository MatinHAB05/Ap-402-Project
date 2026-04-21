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

namespace RestaurantApp.SetPassWordPage_Matin.userControl_SetPassword
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class txtBoxControl : UserControl
    {
        public bool IsHide { get; set; }
        public string txtDemo { get; set; }
        public txtBoxControl()
        {
            InitializeComponent();
            IsHide = false;
            TxtBox_M.Foreground = new SolidColorBrush(Colors.Transparent);
            txtB.Foreground = new SolidColorBrush(Colors.Black);
            txtDemo = "";
        }
        private void SHOWHide(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Button clicked!");
            IsHide = !IsHide;
            if (IsHide)
            {
                TxtBox_M.Foreground = new SolidColorBrush(Colors.Transparent);
                txtB.Foreground = new SolidColorBrush(Colors.Black);
                ButtonImage.Source = new BitmapImage(new Uri("/SetPassWordPage_Matin/images/hide.png", UriKind.Relative));
                TextChanged(sender, e);
            }
            else
            {
                TxtBox_M.Foreground = new SolidColorBrush(Colors.Black);
                txtB.Foreground = new SolidColorBrush(Colors.Transparent);
                ButtonImage.Source = new BitmapImage(new Uri("/SetPassWordPage_Matin/images/show.png", UriKind.Relative));
                TextChanged(sender, e);
            }
        }
        private void TextChanged(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Hi");
            if (IsHide)
            {
                string a = "";
                for (int i = 0; i < txtB.Text.Length; i++)
                {
                    a = a + "*";
                }
                txtB.Text = a;
                
                return;
            }
            txtB.Text = TxtBox_M.Text;

        }
    }
}
