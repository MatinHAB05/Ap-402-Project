


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
using static MainProject.reserrveORorderFoods_CustomerPage_Matin.reserrveORorderFoods_CustomerPage;

namespace MainProject.reserrveORorderFoods_CustomerPage_Matin
{
    /// <summary>
    /// Interaction logic for reserrveORorderFoods_CustomerPage.xaml
    /// </summary>
    public partial class reserrveORorderFoods_CustomerPage : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Food_Category> _categories { get; set; }
        public ObservableCollection<FoodClass> _selectedFoods { get; set; }
        public ICommand RemoveFoodCommand { get; private set; }
        public ICommand CommentFUN { get; private set; }

        public ICommand FUN { get; private set; }
        public ObservableCollection<Food_Category> Categories
        {
            get { return _categories; }
            set { _categories = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Categories")); }
        }
        public ObservableCollection<FoodClass> SelectedFoods
        {
            get { return _selectedFoods; }
            set { _selectedFoods = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedFoods")); }
        }
        //public
        public reserrveORorderFoods_CustomerPage()
        {
            InitializeComponent();
            this.DataContext = this;
            MainListView.Visibility = Visibility.Hidden;

            //if(resturants has OK)
            //radioButton1.Visibility = Visibility.Hidden;

            Categories = new ObservableCollection<Food_Category>
            {
                  new Food_Category
                  {
                      CategoryName="Cat1",
                      Foods = new ObservableCollection<FoodClass>
                                    {
                            new FoodClass{Name="FoodNam1" , price=159 , xBar=4.23 , Raw_materials=CommaMethod("abc,def,geh") ,RemNumber=5 },
                            new FoodClass{Name="FoodNam2" , price=159 , xBar=4.23 , Raw_materials=CommaMethod("abc,def,geh") ,RemNumber=5 },
                            new FoodClass{Name="FoodNam3" , price=159 , xBar=4.23 , Raw_materials=CommaMethod("abc,def,geh"),RemNumber=5  }
                                    }
                  } ,

                  new Food_Category
                  {
                      CategoryName="Cat2",
                      Foods = new ObservableCollection<FoodClass>
                                    {
                            new FoodClass{Name="FoodNam1" , price=159 , xBar=4.23 , Raw_materials=CommaMethod("abc,def,geh"),RemNumber=5  },
                            new FoodClass{Name="FoodNam2" , price=159 , xBar=4.23 , Raw_materials=CommaMethod("abc,def,geh"),RemNumber=5  },
                            new FoodClass{Name="FoodNam3" , price=159 , xBar=4.23 , Raw_materials=CommaMethod("abc,def,geh") , RemNumber = 5}
                                    }
                  } ,

                  new Food_Category
                  {
                      CategoryName="Cat3",
                      Foods = new ObservableCollection<FoodClass>
                                    {
                            new FoodClass{Name="FoodNam1" , price=159 , xBar=4.23 , Raw_materials=CommaMethod("abc,def,geh"),RemNumber=5  },
                            new FoodClass{Name="FoodNam2" , price=159 , xBar=4.23 , Raw_materials=CommaMethod("abc,def,geh"),RemNumber=5  },
                            new FoodClass{Name="FoodNam3" , price=159 , xBar=4.23 , Raw_materials=CommaMethod("abc,def,geh") , RemNumber = 5}
                                    }
                  } ,


                  new Food_Category
                  {
                      CategoryName="Cat4",
                      Foods = new ObservableCollection<FoodClass>
                                    {
                            new FoodClass{Name="FoodNam1" , price=159 , xBar=4.23 , Raw_materials=CommaMethod("abc,def,geh"),RemNumber=5  },
                            new FoodClass{Name="FoodNam2" , price=159 , xBar=4.23 , Raw_materials=CommaMethod("abc,def,geh"),RemNumber=5  },
                            new FoodClass{Name="FoodNam3" , price=159 , xBar=4.23 , Raw_materials=CommaMethod("abc,def,geh") , RemNumber = 5}
                                    }
                  } ,

                  new Food_Category
                  {
                      CategoryName="Cat5",
                      Foods = new ObservableCollection<FoodClass>
                                    {
                            new FoodClass{Name="FoodNam1" , price=159 , xBar=4.23 , Raw_materials=CommaMethod("abc,def,geh") },
                            new FoodClass{Name="FoodNam2" , price=159 , xBar=4.23 , Raw_materials=CommaMethod("abc,def,geh") },
                            new FoodClass{Name="FoodNam3" , price=159 , xBar=4.23 , Raw_materials=CommaMethod("abc,def,geh") }
                                    }
                  } ,

            };

            SelectedFoods = new ObservableCollection<FoodClass>();

            FUN = new RelayCommand<FoodClass>(AddToSelectedFoods);

            CommentFUN=new RelayCommand<FoodClass>(CommnetSection);

            RemoveFoodCommand = new RelayCommand<FoodClass>(RemoveFromSelectedFoods);




        }
        private void AddToSelectedFoods(FoodClass food)
        {
            if (food.RemNumber <= 0) { MessageBox.Show($"{food.Name} is over!","Attention",MessageBoxButton.OK,MessageBoxImage.Warning); return; }
            SelectedFoods.Add(food);
            food.RemNumber--;
            MainListView.Visibility = Visibility.Visible;

        }

        private void RemoveFromSelectedFoods(FoodClass food)
        {
            SelectedFoods.Remove(food);
            food.RemNumber++;

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

        public class FoodClass
        {
            public string Name { get; set; }
            public string Raw_materials { get; set; }
            public double price { get; set; }
            //public imag???
            public double xBar { get; set; }
            public int RemNumber { get; set; }

            //public FoodClass(string name, string raw_materials, double price, double xBar)
            //{
            //    Name = name;
            //    Raw_materials = raw_materials;
            //    this.price = price;
            //    this.xBar = xBar;
            //}
        }

        public class Food_Category
        {
            public string CategoryName { get; set; }
            public ObservableCollection<FoodClass> Foods { get; set; }
            //public Food_Category(string categoryName, ObservableCollection<FoodClass> foods)
            //{
            //    CategoryName = categoryName;
            //    Foods = foods;
            //}
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

