using MainProject.CustomerMainPage_Parham.CustomerMainPage;
using MainProject.Public_Classes;
using MainProject.SetPassWordPage_Matin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class ProfilePage : Window , INotifyPropertyChanged
    {    
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _address;
        public string Local_Address { get{ return _address; } set { _address = value; PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("Local_Address") ); }  }
      
        private string _Email;

        public string EEmail { get { return _Email; } set { _Email = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EEmail")); } }

        internal User CurrentUser {  get; set; }
        public CustomerMainPage PreviousPage {  get; set; }
        internal ProfilePage(CustomerMainPage prepage)
        {
            InitializeComponent();
            this.PreviousPage = prepage;
            CurrentUser = prepage.CurrentUser;
            UserName.Text = CurrentUser.UserName;
            EEmail = CurrentUser.Email_Unique;
            Local_Address = CurrentUser.Address;
            Gender.Text = ((Gender)CurrentUser.Gender).ToString();
            CustomerTypeBlock.Text = "you account type is " +  ((CustomerType)CurrentUser.customerType).ToString();
            Phone.Text = CurrentUser.Phone;
            LastName.Text = CurrentUser.LastName;
            Name.Text = CurrentUser.Name;


            //form
            if (CurrentUser.customerType == CustomerType.Bronze) { r1.IsChecked = true; }
            if (CurrentUser.customerType == CustomerType.Silver) { r2.IsChecked = true; }
            if (CurrentUser.customerType == CustomerType.Gold) { r3.IsChecked = true; }
            this.DataContext = this;

        }
        private void Change_Address_Click(object sender, RoutedEventArgs e)
        {
            if (AddressBox.Text.Length == 0 || AddressBox.Text==null) return;
            Local_Address = AddressBox.Text;

        }
        private void Change_Email_Click(object sender, RoutedEventArgs e)
        {
            string Error = "";
            if (EmailEdit.Text.Length == 0 || EmailEdit.Text == null) return;

            //right
            if(!Regex.IsMatch(EmailEdit.Text, @"^[A-Z0-9a-z_]{3,32}\@[A-Za-z]{3,32}\.[A-Za-z]{2,3}$"))
            {
                Error += "ادرس ایمیل شما ناشناخته میباشد" + "\n";
            
                MessageBox.Show(Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Error == "")
            {
                EEmail = EmailEdit.Text;
                return;
            }
            else
            {
            matinLabel:
                MessageBoxResult a = MessageBox.Show(Error + "ردیفه؟", "UNVALID INPUT", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (a == MessageBoxResult.Yes) { return; }
                if (a == MessageBoxResult.No) { goto matinLabel; }
            }



        }
        private void Change_CustomerType_Click(object sender, RoutedEventArgs e)
        {   
            if (r1.IsChecked == true) { CurrentUser.customerType =CustomerType.Bronze; CustomerTypeBlock.Text = "you account type is " +"Bronze"; }
            if (r2.IsChecked == true) { CurrentUser.customerType = CustomerType.Silver; CustomerTypeBlock.Text = "you account type is " +"Silver"; }
            if (r3.IsChecked == true) { CurrentUser.customerType = CustomerType.Gold; CustomerTypeBlock.Text = "you account type is " +"Gold"; }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveBeforeSave();
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            SaveBeforeSave();
            CustomerMainPage back = new CustomerMainPage(CurrentUser);
            back.Show();
            this.Close();

        }
        private void SaveBeforeSave()
        {

            //Saved Edits
            CurrentUser.Email_Unique = EmailBlock.Text;
            CurrentUser.Address = AddressBlock.Text;
            //CustomerMainPage customerMainPage = new CustomerMainPage(CurrentUser);
            //customerMainPage.Show();
            //end Save

            //Save in Json
            string jsonUser = File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\User\All_Users.json");

            List<User> AllUsers = JsonConvert.DeserializeObject<List<User>>(jsonUser);
            int i = 0;
            foreach (User u in AllUsers)
            {
                if (u.UserName == CurrentUser.UserName) { break; }
                i++;
            }
            AllUsers[i] = CurrentUser;
            string jsonEnd = JsonConvert.SerializeObject(AllUsers, Formatting.Indented);
            File.WriteAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\User\All_Users.json", jsonEnd);
        }
    }
}
