using MainProject.CustomerMainPage_Parham.CustomerMainPage;
using MainProject.Public_Classes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace MainProject.reserrveORorderFoods_CustomerPage_Matin
{
    /// <summary>
    /// Interaction logic for reserrveORorderFoods_CustomerPage.xaml
    /// </summary>
    public partial class reserrveORorderFoods_CustomerPage : Window, INotifyPropertyChanged
    {
        public User CurrentUser { get; set; }
        public Restaurant CurrentREStaurant { get; set; }
        public ObservableCollection<Category> _categories { get; set; }
        public ObservableCollection<FoodClass> _selectedFoods { get; set; }
        public ICommand RemoveFoodCommand { get; private set; }
        public ICommand CommentFUN { get; private set; }
        public ICommand FullScreenIMG { get; private set; }


        public ICommand FUN { get; private set; }
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Categories")); }
        }
        public ObservableCollection<Category> First {  get; set; }
        public ObservableCollection<Category> Demo { get; set; }

        public ObservableCollection<FoodClass> SelectedFoods
        {
            get { return _selectedFoods; }
            set { _selectedFoods = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedFoods")); }
        }
        //public
        public reserrveORorderFoods_CustomerPage(User CurUser , Restaurant CurRes)
        {
            InitializeComponent();
            this.DataContext = this;
            MainListView.Visibility = Visibility.Hidden;
            CurrentUser = CurUser;
            CurrentREStaurant= CurRes;
            //if(resturants has OK)
            //radioButton1.Visibility = Visibility.Hidden;
            Categories = new ObservableCollection<Category>( CurRes.Menu);

            SelectedFoods = new ObservableCollection<FoodClass>();

            FUN = new RelayCommand<FoodClass>(AddToSelectedFoods);

            CommentFUN=new RelayCommand<FoodClass>(CommnetSection);

            RemoveFoodCommand = new RelayCommand<FoodClass>(RemoveFromSelectedFoods);
            FullScreenIMG = new RelayCommand<FoodClass>(FullIMAGE);

            First = new ObservableCollection<Category>();
            foreach(Category c in Categories) { First.Add(c.cClone());}

            Demo = new ObservableCollection<Category>();
            foreach (Category c in Categories) { Demo.Add(c.cClone()); }

            CategoryLIST_VIEW.ItemsSource = Categories;
        }
        private void AddToSelectedFoods(FoodClass food)
        {
            if (food.RemNumber <= 0) { MessageBox.Show($"{food.Name} is over!","Attention",MessageBoxButton.OK,MessageBoxImage.Warning); return; }
            SelectedFoods.Add(food);
            food.RemNumber--;

            Demo = new ObservableCollection<Category>();
            foreach (Category c in Categories) { Demo.Add(c.cClone()); }
            Categories.Clear();
            foreach (Category c in Demo) { Categories.Add(c.cClone()); }
            
            CategoryLIST_VIEW.ItemsSource = Categories;
            

            MainListView.Visibility = Visibility.Visible;

        }
        private void FullIMAGE(FoodClass food)
        {
            bool HaveImage=true;
            if(food.Image_Path == null || food.Image_Path=="") { HaveImage = false; }
           Window1 demo = new Window1(food.Image_Path,HaveImage); demo.Show();


        }
        private void RemoveFromSelectedFoods(FoodClass food)
        {
            SelectedFoods.Remove(food);
            //food.RemNumber++;
            foreach(Category Cat in Categories)
            {
                if (Cat.Name == food.FoodCategory)
                {
                    foreach(FoodClass fc in Cat.Foods)
                    {
                        if(fc.Name == food.Name && fc.FoodID == food.FoodID)
                        {
                            fc.RemNumber++;
                            break;
                        }
                    }
                    break;
                }
            }

            Demo = new ObservableCollection<Category>();
            foreach (Category c in Categories) { Demo.Add(c.cClone()); }
            Categories.Clear();
            foreach (Category c in Demo) { Categories.Add(c.cClone()); }

            CategoryLIST_VIEW.ItemsSource = Categories;


            if (MainListView.Items.Count == 0)
            {
                MainListView.Visibility = Visibility.Hidden;

            }
        }

        private void CommnetSection(FoodClass food)
        {
            MessageBox.Show("HI MATIN");
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public static string CommaMethod(string s)
        {
            string a = "";
            string[] Sep = s.Split(",")
            .Select(s => s.Trim()).ToArray();
            a = String.Join('\n', Sep);
            return a;

        }


        private void AddToList(FoodClass food)
        {
            MessageBox.Show($"{food.Name},{food.price}.{food.xBar}");
        }

        private void CommentSection(object sender, RoutedEventArgs e)
        {

        }

        private void Pay_Button(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            CustomerMainPage customerMainPage = new CustomerMainPage(CurrentUser);
            customerMainPage.Show();

        }
    }


    public class RelayCommand<T> : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        private readonly Action<T> _execute;
        private readonly Predicate<T> _canExecute;
        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        public void Execute(object? parameter) => _execute((T)parameter);
    }
}

