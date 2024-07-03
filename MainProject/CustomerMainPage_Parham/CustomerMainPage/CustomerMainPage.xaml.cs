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
using MainProject.Public_Classes;

namespace MainProject.CustomerMainPage_Parham.CustomerMainPage
{
    public partial class CustomerMainPage : Window, INotifyPropertyChanged
    {
        internal CustomerMainPage(User user)
        {
            InitializeComponent();
            //SearchList.ItemsSource = names;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Clear(object sender, RoutedEventArgs e)
        {

        }
        private void SearchByStars(object sender, RoutedEventArgs e)
        {

        }
        private void SearchByCity(object sender, RoutedEventArgs e)
        {

        }
        private void SearchByName(object sender, RoutedEventArgs e)
        {

        }
        private void Dine_In(object sender, RoutedEventArgs e)
        {

        }
        private void Delivery_In(object sender, RoutedEventArgs e)
        {

        }
    }
}
