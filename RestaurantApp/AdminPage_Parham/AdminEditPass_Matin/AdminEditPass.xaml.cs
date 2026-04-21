using RestaurantApp.AdminPage_Parham.AdminPage;
using RestaurantApp.Public_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

namespace RestaurantApp.AdminPage_Parham.AdminEditPass_Matin
{
    /// <summary>
    /// Interaction logic for AdminEditPass.xaml
    /// </summary>
    public partial class AdminEditPass : Window
    {
        public Admin Admin { get; set; }
        bool Must_Off { get; set; }
        public AdminEditPass(Admin admin)
        {
            InitializeComponent();
            this.Admin = admin;
            Must_Off = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string old = OOLLDD.Text;
            string nnew = NNEEWW.Text;
            string Error;
            if (old == "" || nnew == "") { MessageBox.Show("You Must Fill the All Text Boxes"); return; }

            if (!Regex.IsMatch(nnew, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{8,32}$"))
            {
                Error = "رمز عبور باید شامل حداقل یک حرف بزرگ و حداقل یک حرف کوچک و حداقل یک عدد و تعداد کارکتر های ان حداکثر 32 و حداقل 8 کاراکتر باشد " + "\n";
                MessageBox.Show(Error); return;
            }
            if (old != Admin.Password)
            {
                Error = "رمز فعلی  به نادرستی وارد شده است.دوباره بررسی کنید" + "\n";
                MessageBox.Show(Error); return;
            }
            Admin.Password = nnew;
            List<Admin> admins = JsonConvert.DeserializeObject<List<Admin>>(File.ReadAllText(MainWindow.Get_Dir_ALL_ADMIN_json()));
            int r = 0;
            foreach (Admin a in admins)
            {
                if (a.UserName == Admin.UserName) { break; }
                r++;
            }
            admins[r].Password = nnew;
            File.WriteAllText(MainWindow.Get_Dir_ALL_ADMIN_json(),
                JsonConvert.SerializeObject(admins, Formatting.Indented));
            Must_Off = false;
            MessageBox.Show("Done");

            AdminPage_Parham.AdminPage.AdminPage admisssn = new AdminPage_Parham.AdminPage.AdminPage(Admin);
            admisssn.Show();



            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Must_Off) Application.Current.Shutdown();

        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            Must_Off = false;
            AdminPage_Parham.AdminPage.AdminPage page = new AdminPage.AdminPage(Admin);
            page.Show();
            this.Close();
        }
    }
}
