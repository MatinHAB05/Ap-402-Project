using MainProject.Public_Classes;
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

namespace MainProject.OrderHistoryPage_Matin
{
    /// <summary>
    /// Interaction logic for ReviewUnreviewedComplaints_Page.xaml
    /// </summary>
    public partial class OrderHistoryPage_CustomerPanel : Window
    {

        public class OrderHistory
        {
            public string name { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public int Id { get; set; }
            public string NameRes { get; set; }
            public double rate { get; set; }
            public string comment { get; set; }
            public OrderHistory(string Name, string lastanme, string Username, int Id, string NameRes, double rate, string comment)
            {
                this.name = Name;
                this.LastName = lastanme;
                this.UserName = Username;
                this.Id = Id;
                this.comment = comment;
                this.NameRes = NameRes;
                this.rate = rate;
            }
        }
        internal OrderHistoryPage_CustomerPanel(User user)
        {
            InitializeComponent();
            this.DataContext = this;
            EditBut.Visibility = Visibility.Visible;
            SaveBut.Visibility = Visibility.Hidden;
            //For Now 
            List<OrderHistory> demo = new List<OrderHistory>
            {
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment"),
                new  OrderHistory("Matin","HasanaaliBaki","UserName",12345,"ResName",4.23,"This is Comment")

            };
            DataGridResault.ItemsSource = demo;

        }

        private void EditEvent(object sender, RoutedEventArgs e)
        {
            ColRate.IsReadOnly = false;
            ColComment.IsReadOnly = false;

            //MessageBox.Show("Edit Method is ON");

            EditBut.Visibility = Visibility.Hidden;
            SaveBut.Visibility = Visibility.Visible;

        }
        private void SaveEvent(object sender, RoutedEventArgs e)
        {
            ColRate.IsReadOnly = true;
            ColComment.IsReadOnly = true;
            //MessageBox.Show("Save Method is ON");

            //Saved the Edits in Logic Code!!!


            MessageBox.Show("Saved!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            EditBut.Visibility = Visibility.Visible;
            SaveBut.Visibility = Visibility.Hidden;

        }
    }
}
