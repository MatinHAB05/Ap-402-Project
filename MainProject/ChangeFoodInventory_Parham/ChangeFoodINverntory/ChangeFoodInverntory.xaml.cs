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
using System.Text.Json;
using MainProject.Public_Classes;

namespace MainProject.ChangeFoodInventory_Parham.ChangeFoodINverntory
{
    public partial class ChangeFoodInverntory : Window
    {
        List<FoodClass> foodList;
        internal ChangeFoodInverntory(Restaurant restaurant)
        {
            List<FoodClass> foodList = new List<FoodClass>();
            InitializeComponent();
            foreach(var i in restaurant.Menu)
            {
                foreach(var j in i.Foods)
                {
                    foodList.Add(j);
                }
            }
            NamesButton.ItemsSource = foodList;

        }
        private void Change_Food_Inventory_Button(object sender, RoutedEventArgs e)
        {

        }
    }
}
