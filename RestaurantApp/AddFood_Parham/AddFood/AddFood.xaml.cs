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
using RestaurantApp.ChangeMenu_Parham.ChangeMenu;
using RestaurantApp.Public_Classes;
using Microsoft.Win32;
using Application = System.Windows.Application;

namespace RestaurantApp.AddFood_Parham.AddFood
{
    public partial class AddFood : Window
    {
        Category Category;
        int foodRemNumber;
        List<string> FoodMaterial;
        string FoodName;
        string CategoryName;
        double price;
        Restaurant restauranT;
        string? image_p;
        public bool Window_Event { get; set; }
        internal AddFood(Restaurant restaurant)
        {
            this.Window_Event = true;
            restauranT = restaurant;
            InitializeComponent();
        }
        private void Complete_Click(object sender, RoutedEventArgs e)
        {
            if ((Price.Text != "") && (Category_Name.Text != "") && (Food_Name.Text != "") && (Materials.Text != "") && (Remaine_Number.Text != ""))
            {
                bool ContinueOrNot = true;
                try
                {
                    this.price = Convert.ToDouble(Price.Text);

                }
                catch
                {
                    MessageBox.Show("Your Entered Price was not right", "Number Wrong", MessageBoxButton.OK, MessageBoxImage.Error);
                    ContinueOrNot = false;
                }
                if (ContinueOrNot)
                {
                    try
                    {
                        this.foodRemNumber = Convert.ToInt32(Remaine_Number.Text);

                    }
                    catch
                    {
                        MessageBox.Show("Your Entered Remained number was not right", "Number Wrong", MessageBoxButton.OK, MessageBoxImage.Error);
                        ContinueOrNot = false;
                    }
                }
                if (ContinueOrNot)
                {
                    this.CategoryName = Category_Name.Text;
                    this.FoodName = Food_Name.Text;
                    this.FoodMaterial = Materials.Text.Split(',').ToList<string>();
                    FoodClass food = new FoodClass(this.CategoryName, this.FoodName, this.price , this.FoodMaterial, this.foodRemNumber, this.image_p);
                    this.restauranT.RestaurantOverRide_AddFood_InJsonFile(food, new Category(this.CategoryName, null));
                    MessageBox.Show("Food Added Successfully", "food added", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Please Enter all fields", "You did not enter all fields",  MessageBoxButton.OK , MessageBoxImage.Error);
            }
            
        }
        private void BackPage(object sender, RoutedEventArgs e)
        {
            ChangeMenu changeMenu = new ChangeMenu(restauranT);
            this.Window_Event = false;
            this.Close();
            changeMenu.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.Window_Event)
            {
                Application.Current.Shutdown();
            }
        }
        private void Image_Picked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JPG images | *.jpg|PNG image| *.png",
                InitialDirectory = MainWindow.Get_Dir_Images(), // Use absolute path with double backslashes
                Title = "Please pick a food",
                Multiselect = false
            };

            bool? pickedOrNot = openFileDialog.ShowDialog();

            if (pickedOrNot == true)
            {
                this.image_p = openFileDialog.FileName;
            }
            else
            {
                this.image_p = null;
            }
        }
    }
}
