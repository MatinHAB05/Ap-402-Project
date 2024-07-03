using MainProject.Public_Classes;
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

namespace MainProject.ProfilePage_Parham.ProfilePage
{
    public partial class ProfilePage : Window
    {
        internal ProfilePage(User user)
        {
            InitializeComponent();
            //UserName.Text = userName;
            //Email.Text = email;
            //Address.Text = address;
            //Gender.Text = gender;
            //CustomerType.Text = "you account type is " + customerType;
            //Phone.Text = phone;
            //LastName.Text = lastName;
            //Name.Text = name;
        }
        private void Change_Address_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Change_Email_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Change_CustomerType_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
