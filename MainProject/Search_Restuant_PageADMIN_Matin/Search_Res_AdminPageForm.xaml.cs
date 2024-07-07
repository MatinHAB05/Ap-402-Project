using MainProject.AdminPage_Parham.AdminPage;
using MainProject.Public_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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

namespace MainProject.Search_Restuant_PageADMIN_Matin
{
    /// <summary>
    /// Interaction logic for SearchPageForm.xaml
    /// </summary>
    public partial class Search_Res_AdminPageForm : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Resturants_FORNOW> resturants_FORNOWs;
        public ObservableCollection<Resturants_FORNOW> begin;

        public List<Restaurant>? restaurants;
        public List<Complaint>? complaints;

        public Admin admin {  get; set; }
        private double _MinPointsSearch;
        public double MinPointsSearch
        {
            get { return _MinPointsSearch; } set { _MinPointsSearch = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinPointsSearch")); }

        }
        private double _MaxPointsSearch;
        public double MaxPointsSearch
        {
            get { return _MaxPointsSearch; }
            set { _MaxPointsSearch = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaxPointsSearch")); }

        }

        public class Resturants_FORNOW : INotifyPropertyChanged
        {
            public string name {  get; set; }
            public string city {  get; set; }
            public int N_NotComplaints {  get; set; }
            public int N_Complaints { get; set; }
            public double point {  get; set; }
            public Resturants_FORNOW() { }
            public Resturants_FORNOW(string name, string city, int NN, int YC, double point)
            {
                this.name = name;
                this.city = city;   
                this.N_NotComplaints = NN;
                this.N_Complaints=YC;
                this.point = point;
            }

            public event PropertyChangedEventHandler? PropertyChanged;

            public Resturants_FORNOW cClone()
            {
                Resturants_FORNOW demo = new Resturants_FORNOW();
                demo.name = name;
                demo.city = city;
                demo.point = point;
                demo.N_NotComplaints= N_NotComplaints;
                return demo;
            }
        }
        public Search_Res_AdminPageForm(Admin admin)
        {
            this.admin = admin;
            InitializeComponent();
            //Data
            restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Restaurant\All_Restaurant.json"));
            complaints = JsonConvert.DeserializeObject<List<Complaint>>(File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Complaint\All_Complaints.json"));

            //DataGridResault.ItemsSource = demo;
            resturants_FORNOWs = new ObservableCollection<Resturants_FORNOW>(restaurants.Select(rs => { rs.Calculate(); ; return new Resturants_FORNOW
            {
                name = rs.RestaurantName,
                city = rs.CityName,
                N_NotComplaints = Complaint.GetNumberISchecked(rs.UserName,false),
                point = rs.Rating,
                N_Complaints=Complaint.GetNumberISchecked(rs.UserName,true)
            };
            }
            ).ToList());
            //*****
            DataGridResault.ItemsSource = resturants_FORNOWs;
            begin = new ObservableCollection<Resturants_FORNOW>();
            foreach(Resturants_FORNOW a in resturants_FORNOWs)
            {
                begin.Add(a.cClone());
            }
            this.DataContext = this;

        }

        public event PropertyChangedEventHandler? PropertyChanged;



        private void sliderPoint_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MinPointsSearch = Math.Round(sliderPoint.Value, +2);
            MaxPointsSearch = Math.Round(sliderPoint2.Value, +2);


        }



        private void RemoveFilters(object sender, RoutedEventArgs e)
        {
            if (radioButton.IsChecked == true || radioButton2.IsChecked == true) { radioButton.IsChecked = radioButton2.IsChecked = false; }
            ResName.txtBoxSerach.Clear();
            CitName.txtBoxSerach.Clear();
            sliderPoint.Value = 0;
            sliderPoint2.Value = 10;
            resturants_FORNOWs.Clear();
            foreach(Resturants_FORNOW a in begin)
            {
                resturants_FORNOWs.Add(a.cClone()); 
            }

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            radioButton.Focus();
            if (ResName.IsClicked == 1)
            {
                ResName.IsClicked = 0;
                ResName.txtBoxSerach.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220));
                ResName.imgD.Source = new BitmapImage(new Uri("\\Search_Restuant_PageADMIN_Matin\\Images\\s1.jpg", UriKind.Relative));
            }

            if (CitName.IsClicked == 1)
            {
                CitName.IsClicked = 0;
                CitName.txtBoxSerach.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220));
                CitName.imgD.Source = new BitmapImage(new Uri("\\Search_Restuant_PageADMIN_Matin\\Images\\s1.jpg", UriKind.Relative));
             }
    }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            //AdminPage Pre = new AdminPage(admin);
            //Pre.Show();
        }

        private void SEARCH(object sender, RoutedEventArgs e)
        {
            resturants_FORNOWs.Clear();
            foreach (Resturants_FORNOW x in begin)
            {
                resturants_FORNOWs.Add(x.cClone());
            }
            string name = ResName.txtBoxSerach.Text.Trim();
            //MessageBox.Show(name);
            //MessageBox.Show("Resname5".Contains("5").ToString());
            //MessageBox.Show("TTT".Contains("").ToString());
            string city = CitName.txtBoxSerach.Text.Trim();
            double minPoint = sliderPoint.Value;
            double maxPoint = sliderPoint2.Value;
            int? NO = 0;
            int? YEs = 0;
            if (radioButton2.IsChecked == true) { NO = 1; }
            if (radioButton.IsChecked == true) { YEs = 1; }
            ObservableCollection<Resturants_FORNOW> demo = new ObservableCollection<Resturants_FORNOW>(resturants_FORNOWs.Where(rs=>rs.city.Contains(city) && rs.name.Contains(name) && rs.point>=minPoint && rs.point<=maxPoint && rs.N_NotComplaints>=NO && rs.N_Complaints>=YEs).ToList());
            resturants_FORNOWs.Clear();
            foreach (Resturants_FORNOW x in demo)
            {
                resturants_FORNOWs.Add(x.cClone());
            }
            //DataGridResault.ItemsSource= resturants_FORNOWs;
            //MessageBox.Show(demo.Count.ToString());

            //resturants_FORNOWs = demo;
            //MessageBox.Show(resturants_FORNOWs.Count.ToString());

        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            this.Close();
            AdminPage back = new AdminPage(admin);
            back.Show();
        }
    }
}
