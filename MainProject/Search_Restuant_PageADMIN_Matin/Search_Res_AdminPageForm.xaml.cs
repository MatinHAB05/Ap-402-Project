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

namespace MainProject.Search_Restuant_PageADMIN_Matin
{
    /// <summary>
    /// Interaction logic for SearchPageForm.xaml
    /// </summary>
    public partial class Search_Res_AdminPageForm : Window, INotifyPropertyChanged
    {
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

        public class Resturants_FORNOW
        {
            public string name {  get; set; }
            public string city {  get; set; }
            public int N_NotComplaints {  get; set; }
            public double point {  get; set; }
            public Resturants_FORNOW(string name, string city, int N,double point)
            {
                this.name = name;
                this.city = city;   
                this.N_NotComplaints = N;
                this.point = point;
            }
        }
        public Search_Res_AdminPageForm(Admin admin)
        {
            this.admin=admin;
            InitializeComponent();
            this.DataContext = this;
            //For Now 
            List<Resturants_FORNOW> demo = new List<Resturants_FORNOW> {
                new Resturants_FORNOW("DemeNaadasddsaddsaaadsaadme","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeNaadasddsaddsaaadsaadme","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeNaadasddsaddsaaadsaadme","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeNaadasddsaddsaaadsaadme","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeNaadasddsaddsaaadsaadme","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeNaadasddsaddsaaadsaadme","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21),
                new Resturants_FORNOW("DemeName","DemoCity",97,4.21)};
            DataGridResault.ItemsSource = demo;


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
            D.txtBoxSerach.Clear();
            D2.txtBoxSerach.Clear();
            sliderPoint.Value = 0;
            sliderPoint2.Value = 5;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            radioButton.Focus();
            if (D.IsClicked == 1)
            {
                D.IsClicked = 0;
                D.txtBoxSerach.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220));
                D.imgD.Source = new BitmapImage(new Uri("\\Search_Restuant_PageADMIN_Matin\\Images\\s1.jpg", UriKind.Relative));
            }

            if (D2.IsClicked == 1)
            { 
            D2.IsClicked = 0;
            D2.txtBoxSerach.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220));
            D2.imgD.Source = new BitmapImage(new Uri("\\Search_Restuant_PageADMIN_Matin\\Images\\s1.jpg", UriKind.Relative));
             }
    }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            AdminPage Pre = new AdminPage(admin);
            Pre.Show();
        }
    }
}
