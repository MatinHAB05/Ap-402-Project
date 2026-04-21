using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Formats.Asn1;
using System.Globalization;
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
using static RestaurantApp.Search_Restuant_PageADMIN_Matin.Search_Res_AdminPageForm;


namespace RestaurantApp.Review_Search_OrderAndReservation_ResturantsPanel_Matin
{
    /// <summary>
    /// Interaction logic for Review_Search_OrderAndReservation_ResturantsPage.xaml
    /// </summary>
    public partial class Review_Search_OrderAndReservation_ResturantsPage : Window, INotifyPropertyChanged
    {
       
        private double _MinPricesSearch;
        public double MinPricesSearch
        {
            get { return _MinPricesSearch; }
            set { _MinPricesSearch = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinPricesSearch")); }

        }
        private double _MaxPricesSearch;
        public double MaxPricesSearch
        {
            get { return _MaxPricesSearch; }
            set { _MaxPricesSearch = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaxPricesSearch")); }

        }

        public DateTime StartDate {
            get { return _StartDate; } set { _StartDate = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartDate")); }
        }
        public DateTime EndDate {
            get { return _EndDate; } set { _EndDate = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EndDate")); }
        }


        private DateTime _StartDate;
        private DateTime _EndDate;
        public enum Type_FORNOW { Reservation,order};
        public class Resturants_FORNOW_RES_panel
        {
            public string Username { get; set; }
            public string phone { get; set; }
            public string foodname {  get; set; }
            public double Price { get; set; }
            public Type_FORNOW ttt {  get; set; }
            public Resturants_FORNOW_RES_panel(string name, string city, string foofname, double Price,Type_FORNOW a)
            {
                this.Username = name;
                this.phone = city;
                this.foodname = foofname;
                this.Price = Price;
                this.ttt = a;
            }
        }
        public Review_Search_OrderAndReservation_ResturantsPage()
        {
            InitializeComponent();
            DatePickerStart.SelectedDate=DateTime.Now;
            DatePickerEnd.SelectedDate=DateTime.Now;  
            this.DataContext = this;
            //For Now 
            List<Resturants_FORNOW_RES_panel> demo = new List<Resturants_FORNOW_RES_panel> {
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",4.21,Type_FORNOW.Reservation),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",421,Type_FORNOW.order),
                new Resturants_FORNOW_RES_panel("DemeName","DemoCity","FoodName",4.21,Type_FORNOW.order) };
            DataGridResault.ItemsSource = demo;


        }

        public event PropertyChangedEventHandler? PropertyChanged;



        private void sliderPrice_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MinPricesSearch = Math.Round(sliderPrice.Value, +2);
            MaxPricesSearch = Math.Round(sliderPrice2.Value, +2);


        }



        private void RemoveFilters(object sender, RoutedEventArgs e)
        {
            if (radioButton.IsChecked == true || radioButton2.IsChecked == true) { radioButton.IsChecked = radioButton2.IsChecked = false; }
            D.txtBoxSerach.Clear();
            D2.txtBoxSerach.Clear();
            D3.txtBoxSerach.Clear();
            sliderPrice.Value = 0;
            sliderPrice2.Value = 5;
            DatePickerEnd.SelectedDate = DateTime.Now;
            DatePickerStart.SelectedDate = DateTime.Now;

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
            if (D3.IsClicked == 1)
            {
                D3.IsClicked = 0;
                D3.txtBoxSerach.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220));
                D3.imgD.Source = new BitmapImage(new Uri("\\Search_Restuant_PageADMIN_Matin\\Images\\s1.jpg", UriKind.Relative));
            }
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DatePickerEnd.SelectedDate.ToString());
        }

        private void ScrollViewer_MouseEnter2(object sender, MouseEventArgs e)
        {
            SC_view2.VerticalScrollBarVisibility=ScrollBarVisibility.Auto;
        }

        private void ScrollViewer_MouseLeave2(object sender, MouseEventArgs e)
        {
            SC_view2.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;

        }

        private void Create_csvFile(object sender, RoutedEventArgs e)
        {
            //IEnumerable<Resturants_FORNOW_RES_panel> records =(IEnumerable<Resturants_FORNOW_RES_panel>)DataGridResault.ItemsSource;
            //string fullpath, relativePath;
            //relativePath = @"CSVtext\abc.csv";
            //fullpath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            //string directory= System.IO.Path.GetDirectoryName(fullpath);
            //if (Directory.Exists(directory)==false){
            //    Directory.CreateDirectory(directory);
            //}



            //using (var writer = new StreamWriter(fullpath))
            //using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            //{
            //    csv.WriteRecords(records);
            //}
            MessageBox.Show("Have Successful!","Build .csv File",MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}
