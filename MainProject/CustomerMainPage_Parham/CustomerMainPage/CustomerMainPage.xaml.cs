using MainProject.ProfilePage_Parham.ProfilePage;
using MainProject.Public_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Metrics;
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
using System.Linq;
using System.Windows.Media.Animation;
using MainProject.OrderHistoryPage_Matin;
using MainProject.Follow_RegisterComplaints_Matin;
using MainProject.reserrveORorderFoods_CustomerPage_Matin;
using MainProject.LoginForm_Matin;
namespace MainProject.CustomerMainPage_Parham.CustomerMainPage
{
    //chatgpt == Icommand else....
    public partial class CustomerMainPage : Window, INotifyPropertyChanged
    {
        bool Must_OFF;

        public ICommand ButtonCommand { get; set; }

        public User CurrentUser;
        public List<Restaurant>? restaurants;
        public CustomerMainPage(User user)
        {
            InitializeComponent();
            Must_OFF = true;
            CurrentUser = user;
            //edit the details of this user!!!
            string jsonRes = File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Restaurant\All_Restaurant.json");
            restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(jsonRes);
            SearchList.ItemsSource = restaurants;
            //SearchList.ItemsSource = names;
            ButtonCommand = new RelayCommand<Restaurant>(OnButtonClicked);
            this.DataContext = this;

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnButtonClicked(Restaurant restaurant)
        {
            // Handle button click for the restaurant
            //MessageBox.Show($"Button clicked for {restaurant.RestaurantName}");
            reserrveORorderFoods_CustomerPage reserrveORorderFoods_CustomerPage = new reserrveORorderFoods_CustomerPage(CurrentUser,restaurant);
            reserrveORorderFoods_CustomerPage.Show();
            Must_OFF = false;
            this.Close();
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            TYPEstatus.Text = "";
            Nametxt.Text = "enter Name";
            Citytxt.Text = "enter City";
            Ratetxt.Text = "enter how many rating";
            XClear.Focus();
        }
        private void SearchAllFilter(object sender, RoutedEventArgs e)
        {
            ReceptionType? Filter_receptionType = null;
            string name = Nametxt.Text.Trim();
            string city = Citytxt.Text.Trim();
            double? rate = null;
            if (Ratetxt.Text == "" || Ratetxt.Text == null)
            {
                rate = 0;
            }
            else
            {
                try
                {

                    rate = Double.Parse(Ratetxt.Text);
                    if (rate < 0 || rate > 10) { throw new Exception(); }
                }
                catch (Exception ex) { MessageBox.Show("Rate Must Be [0,10] !", "Error", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            }
            if (TYPEstatus.Text == "Delivery-In") Filter_receptionType = ReceptionType.Delivery;
            else if (TYPEstatus.Text == "Dine-In") Filter_receptionType = ReceptionType.Dine_In;
            else { MessageBox.Show("UnKnown Reception Type!","Error", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            if (city == "" && name == "")
            {
                SearchList.ItemsSource = restaurants.Select(res => { res.Calculate(); return res; })
                    .Where(res => (res.Rating >= rate) &&(res.receptionType== Filter_receptionType) )
                    .ToList<Restaurant>();


            }
            else
            {
                if (name == "")
                {
                    SearchList.ItemsSource = restaurants.Select(res => { res.Calculate(); return res; })
                       .Where(res => (res.Rating >= rate) && (res.CityName.Contains(city) == true) && (res.receptionType == Filter_receptionType))
                       .ToList<Restaurant>();



                }
                else if (city == "")
                {
                    SearchList.ItemsSource = restaurants.Select(res => { res.Calculate(); return res; })
                                                 .Where(res => (res.Rating >= rate) && (res.RestaurantName.Contains(name) == true) && (res.receptionType == Filter_receptionType))
                                                 .ToList<Restaurant>();

                }
                else
                {
                    SearchList.ItemsSource = restaurants.Select(res => { res.Calculate(); return res; })
                             .Where(res => (res.Rating >= rate) && (res.RestaurantName.Contains(name) == true) && (res.CityName.Contains(city)==true) && (res.receptionType == Filter_receptionType))
                             .ToList<Restaurant>();
                }
            }


        }
        private void Dine_In(object sender, RoutedEventArgs e)
        {
            TYPEstatus.Text = "Dine-In";
            TYPEstatus.FontSize = 10;

        }
        private void Delivery_In(object sender, RoutedEventArgs e)
        {
            TYPEstatus.Text = "Delivery-In";
            TYPEstatus.FontSize = 8;

        }

        private void GoProfilePage(object sender, RoutedEventArgs e)
        {
            ProfilePage profile = new ProfilePage(this);
            profile.Show();
            Must_OFF = false;
            this.Close();
        }

        private void GotoOrderHistoy(object sender, RoutedEventArgs e)
        {
            OrderHistoryPage_CustomerPanel orderHistoryPage = new OrderHistoryPage_CustomerPanel(this);
            orderHistoryPage.Show();
            Must_OFF = false;

            this.Close();
        }

        private void GotoFollow_up_and_register_complaints(object sender, RoutedEventArgs e)
        {
            Follow_RegisterComplaints_CustomerPanel follow_RegisterComplaints_CustomerPanel = new Follow_RegisterComplaints_CustomerPanel(this);
            follow_RegisterComplaints_CustomerPanel.Show();
            Must_OFF = false;

            this.Close();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            SaveBeforeClose();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            Must_OFF = false;

            this.Close();


        }
        private void SaveBeforeClose()
        {

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            SaveBeforeClose();
           if(Must_OFF) Application.Current.Shutdown();

        }
    }
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Predicate<T> _canExecute;

        public RelayCommand(Action<T> execute) : this(execute, null) { }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
