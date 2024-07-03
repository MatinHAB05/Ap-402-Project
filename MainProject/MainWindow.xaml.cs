using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MainProject.RestaurantPanel_Parham.RestaurantPanel;
using MainProject.Public_Classes;

namespace MainProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            List<Category> categories = new List<Category>();
            List<FoodClass> foods = new List<FoodClass>();
            List<Comment> comments = new List<Comment>();
            List<string> rawmar = new List<string>();
            foods.Add(new FoodClass("dariaie", "mahi sefid", 1, 10000, rawmar, 10, comments, "sadpla"));
            categories.Add(new Category("mahi", foods));
            ReceptionType receptionType = ReceptionType.Dine_In;
            Restaurant m = new Restaurant("res" , 12 , "asda" , "asd", "asd" , true, categories , receptionType);
            InitializeComponent();
            RestaurantPanel restauraPanel = new RestaurantPanel( m );
            this.Close();
            restauraPanel.Show();

        }
    }
}