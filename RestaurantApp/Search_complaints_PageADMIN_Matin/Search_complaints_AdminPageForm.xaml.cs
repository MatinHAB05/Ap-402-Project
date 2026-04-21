using RestaurantApp.AdminPage_Parham.AdminPage;
using RestaurantApp.Public_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RestaurantApp.Search_complaints_PageADMIN_Matin
{
    /// <summary>
    /// Interaction logic for SearchPageForm.xaml
    /// </summary>
    public partial class Search_complaints_AdminPageForm : Window, INotifyPropertyChanged
    {
        bool Must_OFF;

        public ObservableCollection<complaints_User_FORNOW> begin {  get; set; }
        public ObservableCollection<complaints_User_FORNOW> comes { get; set; }

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
            public string Response {  get; set; }
            public int ComplaintID {  get; set; }
            public complaints_User_FORNOW(string name , string lastname,string username,string  title , string nameRes , bool isChecked,string response , int ComplainID)
            {
                this.name = name;
                this.Title = title;
                this.LastName = lastname;
                this.IsChecked = isChecked;
                this.NameRes= nameRes;
                this.UserName = username;
                this.Response = response;
                this.ComplaintID = ComplainID;
            }
            public complaints_User_FORNOW() { }
            public complaints_User_FORNOW cClone()
            {
                complaints_User_FORNOW demo = new complaints_User_FORNOW();
                demo.name = this.name;
                demo.LastName = this.LastName;
                demo.UserName = this.UserName;
                demo.Title = this.Title;
                demo.NameRes = this.NameRes;
                demo.IsChecked = this.IsChecked;
                demo.Response = this.Response;
                demo.ComplaintID= this.ComplaintID;
                return demo;
            }
        }
        public Search_complaints_AdminPageForm(Admin admin)
        {
            InitializeComponent();
            Must_OFF = true;
            this.admin = admin;
            this.DataContext = this;
            radioButton3.IsChecked = true;
            List<Complaint> complaints = JsonConvert.DeserializeObject<List<Complaint>>(File.ReadAllText(MainWindow.Get_Dir_ALL_COMPLAINTS_json()));

            comes = new ObservableCollection<complaints_User_FORNOW>
                (
                complaints.Select(com=> new complaints_User_FORNOW
                {
                    IsChecked=com.IsChecked,
                    Title=com.ComplaintTitile,
                    name=User.GetFIRSTNAMEfromjson(com.User_UserName),
                    LastName=User.GetLASTNAMEfromjson(com.User_UserName),
                    UserName = com.User_UserName,
                    NameRes=Restaurant.GetFromUserName(com.RestaurantUserName).RestaurantName,
                    Response=com.Response,
                    ComplaintID=com.ComplainID
                }
                ).ToList());
            begin = new ObservableCollection<complaints_User_FORNOW>();
            foreach(complaints_User_FORNOW a in comes) { begin.Add(a.cClone()); }
            //For Now 

            //DataGridResault.ItemsSource = demo;
            DataGridResault.ItemsSource = comes;


        }

        public event PropertyChangedEventHandler? PropertyChanged;



        //private void sliderPoint_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    MinPointsSearch = Math.Round(sliderPoint.Value, +2);
        //    MaxPointsSearch = Math.Round(sliderPoint2.Value, +2);


        //}

        private void SEARCH(object sender, RoutedEventArgs e)
        {
            comes.Clear();
            foreach (complaints_User_FORNOW a in begin) { comes.Add(a.cClone()); }

            ObservableCollection<complaints_User_FORNOW> demo;
            string userName = UserNameT.txtBoxSerach.Text.Trim();
            string ResName = RestaurantNameT.txtBoxSerach.Text.Trim();
            string title = TitleT.txtBoxSerach.Text.Trim();
            string first = FirstT.txtBoxSerach.Text.Trim();
            string last = LastT.txtBoxSerach.Text.Trim();
            if (radioButton3.IsChecked == true) 
            {
            demo = new ObservableCollection<complaints_User_FORNOW>(comes.Where(cm=>cm.UserName.Contains(userName) && cm.NameRes.Contains(ResName) 
                                && cm.Title.Contains(title) && cm.name.Contains(first) && cm.LastName.Contains(last)).ToList());



                comes.Clear();
                foreach (complaints_User_FORNOW a in demo) { comes.Add(a.cClone()); }
            }

            else
            {
                bool isCheck = true;
                if(radioButton2.IsChecked==true) isCheck=false;
                demo = new ObservableCollection<complaints_User_FORNOW>(comes.Where(cm => cm.UserName.Contains(userName) && cm.NameRes.Contains(ResName)
                        && cm.Title.Contains(title) && cm.name.Contains(first) && cm.LastName.Contains(last)
                        && cm.IsChecked==isCheck
                        
                        ).ToList());

                comes.Clear();
                foreach (complaints_User_FORNOW a in demo) { comes.Add(a.cClone()); }

            }

            //comes = comes.W
            //search

        }

        private void RemoveFilters(object sender, RoutedEventArgs e)
        {
            if (radioButton.IsChecked == true || radioButton2.IsChecked == true) { radioButton.IsChecked = radioButton2.IsChecked = false; }
            UserNameT.txtBoxSerach.Clear();
            TitleT.txtBoxSerach.Clear();
            RestaurantNameT.txtBoxSerach.Clear();
            RestaurantNameT.txtBoxSerach.Clear();
            LastT.txtBoxSerach.Clear();

            comes.Clear();
            foreach (complaints_User_FORNOW a in begin) { comes.Add(a.cClone()); }


        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            radioButton.Focus();
            if (UserNameT.IsClicked == 1)
            {
                UserNameT.IsClicked = 0;
                UserNameT.txtBoxSerach.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220));
                UserNameT.imgD.Source = new BitmapImage(new Uri("\\Search_complaints_PageADMIN_Matin\\Images\\s1.jpg", UriKind.Relative));
            }

            if (TitleT.IsClicked == 1)
            {
                TitleT.IsClicked = 0;
                TitleT.txtBoxSerach.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220));
                TitleT.imgD.Source = new BitmapImage(new Uri("\\Search_complaints_PageADMIN_Matin\\Images\\s1.jpg", UriKind.Relative));
            }
            if (RestaurantNameT.IsClicked == 1)
            {
                RestaurantNameT.IsClicked = 0;
                RestaurantNameT.txtBoxSerach.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220));
                RestaurantNameT.imgD.Source = new BitmapImage(new Uri("\\Search_complaints_PageADMIN_Matin\\Images\\s1.jpg", UriKind.Relative));
            }

            if (FirstT.IsClicked == 1)
            {
                FirstT.IsClicked = 0;
                FirstT.txtBoxSerach.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220));
                FirstT.imgD.Source = new BitmapImage(new Uri("\\Search_complaints_PageADMIN_Matin\\Images\\s1.jpg", UriKind.Relative));
            }
            if (LastT.IsClicked == 1)
            {
                LastT.IsClicked = 0;
                LastT.txtBoxSerach.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220));
                LastT.imgD.Source = new BitmapImage(new Uri("\\Search_complaints_PageADMIN_Matin\\Images\\s1.jpg", UriKind.Relative));
            }
        }
        private void Window_Closing(object sender, CancelEventArgs e)
         {
                SaveBeforeClose();
        if(Must_OFF)   Application.Current.Shutdown();

        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            SaveBeforeClose();
            AdminPage back = new AdminPage(admin);
            back.Show();
            Must_OFF = false;
            this.Close();

        }
        private void SaveBeforeClose()
        {

        }
    }
}
