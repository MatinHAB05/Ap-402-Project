using MainProject.AdminPage_Parham.AdminPage;
using MainProject.Public_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MainProject.Search_complaints_PageADMIN_Matin
{
    /// <summary>
    /// Interaction logic for SearchPageForm.xaml
    /// </summary>
    public partial class Search_complaints_AdminPageForm : Window, INotifyPropertyChanged
    {
        public Admin admin {  get; set; }
        private double _MinPointsSearch;
        public double MinPointsSearch
        {
            get { return _MinPointsSearch; }
            set { _MinPointsSearch = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinPointsSearch")); }

        }
        private double _MaxPointsSearch;
        public double MaxPointsSearch
        {
            get { return _MaxPointsSearch; }
            set { _MaxPointsSearch = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaxPointsSearch")); }

        }

        public class complaints_User_FORNOW
        {
            public string name {  get; set; }
            public string LastName {  get; set; }
            public string UserName { get; set; }
            public string Title { get; set; }
            public string NameRes {  get; set; }
            public bool IsChecked {  get; set; }
            public complaints_User_FORNOW(string name , string lastname,string username,string  title , string nameRes , bool isChecked)
            {
                this.name = name;
                this.Title = title;
                this.LastName = lastname;
                this.IsChecked = isChecked;
                this.NameRes= nameRes;
                this.UserName = username;
            }
        }
        public Search_complaints_AdminPageForm(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            this.DataContext = this;
            //For Now 
            List<complaints_User_FORNOW> demo = new List<complaints_User_FORNOW>
            {
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true)

            };
            DataGridResault.ItemsSource = demo;


        }

        public event PropertyChangedEventHandler? PropertyChanged;



        //private void sliderPoint_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    MinPointsSearch = Math.Round(sliderPoint.Value, +2);
        //    MaxPointsSearch = Math.Round(sliderPoint2.Value, +2);


        //}



        private void RemoveFilters(object sender, RoutedEventArgs e)
        {
            if (radioButton.IsChecked == true || radioButton2.IsChecked == true) { radioButton.IsChecked = radioButton2.IsChecked = false; }
            D.txtBoxSerach.Clear();
            D2.txtBoxSerach.Clear();
            D3.txtBoxSerach.Clear();
            D4.txtBoxSerach.Clear();
            D5.txtBoxSerach.Clear();

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            radioButton.Focus();
            if (D.IsClicked == 1)
            {
                D.IsClicked = 0;
                D.txtBoxSerach.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220));
                D.imgD.Source = new BitmapImage(new Uri("\\Search_complaints_PageADMIN_Matin\\Images\\s1.jpg", UriKind.Relative));
            }

            if (D2.IsClicked == 1)
            {
                D2.IsClicked = 0;
                D2.txtBoxSerach.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220));
                D2.imgD.Source = new BitmapImage(new Uri("\\Search_complaints_PageADMIN_Matin\\Images\\s1.jpg", UriKind.Relative));
            }
            if (D3.IsClicked == 1)
            {
                D3.IsClicked = 0;
                D3.txtBoxSerach.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220));
                D3.imgD.Source = new BitmapImage(new Uri("\\Search_complaints_PageADMIN_Matin\\Images\\s1.jpg", UriKind.Relative));
            }

            if (D4.IsClicked == 1)
            {
                D4.IsClicked = 0;
                D4.txtBoxSerach.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220));
                D4.imgD.Source = new BitmapImage(new Uri("\\Search_complaints_PageADMIN_Matin\\Images\\s1.jpg", UriKind.Relative));
            }
            if (D5.IsClicked == 1)
            {
                D5.IsClicked = 0;
                D5.txtBoxSerach.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220));
                D5.imgD.Source = new BitmapImage(new Uri("\\Search_complaints_PageADMIN_Matin\\Images\\s1.jpg", UriKind.Relative));
            }
        }


        private void Window_Closing(object sender, CancelEventArgs e)
         {
        AdminPage Pre = new AdminPage(admin);
        Pre.Show();
        }
    }
}
