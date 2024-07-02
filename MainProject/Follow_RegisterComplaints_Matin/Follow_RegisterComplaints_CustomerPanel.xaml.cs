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

namespace MainProject.Follow_RegisterComplaints_Matin
{
    /// <summary>
    /// Interaction logic for Follow_RegisterComplaints_CustomerPanel.xaml
    /// </summary>
    public partial class Follow_RegisterComplaints_CustomerPanel : Window
    {
        public class complaints_User_FORNOW
        {
            public string name { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Title { get; set; }
            public string NameRes { get; set; }
            public bool IsChecked { get; set; }
            public string Response { get; set; }
            public complaints_User_FORNOW(string name, string lastname, string username, string title, string nameRes, bool isChecked, string response)
            {
                this.name = name;
                this.Title = title;
                this.LastName = lastname;
                this.IsChecked = isChecked;
                this.NameRes = nameRes;
                this.UserName = username;
                this.Response = response;
            }
        }
        public Follow_RegisterComplaints_CustomerPanel()
        {
            InitializeComponent();
            this.DataContext = this;


            //EditBut.Visibility = Visibility.Visible;
            //SaveBut.Visibility = Visibility.Hidden;
            //For Now 
            List<complaints_User_FORNOW> demo = new List<complaints_User_FORNOW>
            {
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response"),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true,"This is Response")

            };
            DataGridResault.ItemsSource = demo;

        }

        private void AddComplaints(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Added","Info",MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            user1.txtBox.VerticalContentAlignment = VerticalAlignment.Center;
            user2.txtBox.VerticalContentAlignment = VerticalAlignment.Center;
            user1.txtBox.MaxLength = 68;
            user2.txtBox.MaxLength = 68;

            user1.txtBox.HorizontalContentAlignment = HorizontalAlignment.Left;
            user2.txtBox.HorizontalContentAlignment = HorizontalAlignment.Left;

            user3.txtBox.VerticalContentAlignment = VerticalAlignment.Top;
            user3.txtBox.HorizontalContentAlignment = HorizontalAlignment.Left;
            user3.txtBox.TextWrapping = TextWrapping.Wrap;
        }

        //private void EditEvent(object sender, RoutedEventArgs e)
        //{
        //    ColResponse.IsReadOnly = false;
        //    //MessageBox.Show("Edit Method is ON");

        //    EditBut.Visibility = Visibility.Hidden;
        //    SaveBut.Visibility = Visibility.Visible;

        //}
        //private void SaveEvent(object sender, RoutedEventArgs e)
        //{
        //    ColResponse.IsReadOnly = true;
        //    //MessageBox.Show("Save Method is ON");

        //    //Saved the Edits in Logic Code!!!


        //    MessageBox.Show("Saved!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        //    EditBut.Visibility = Visibility.Visible;
        //    SaveBut.Visibility = Visibility.Hidden;

        //}
    }
}
