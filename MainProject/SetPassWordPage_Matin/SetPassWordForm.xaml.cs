using MainProject.LoginForm_Matin;
using MainProject.Public_Classes;
using MainProject.SignInPage_Matin;
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

namespace MainProject.SetPassWordPage_Matin
{
    /// <summary>
    /// Interaction logic for SetPassWordForm.xaml
    /// </summary>
    public partial class SetPassWordForm : Window
    {
        public int Email_CodeReal {  get; set; }
        internal User user { get; set; }
        int clodeAUTO;
        public SignInForm PerviousForm { get; set; }


        internal SetPassWordForm(User user , SignInForm PreviosPage , int emailcode)
        {
            InitializeComponent();
            this.user = user;
            //PreviosPage.Show();
            this.Email_CodeReal=emailcode;
            this.PerviousForm = PreviosPage;
            clodeAUTO = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Error = "";
            bool IsInt = true;
            bool Ispass=true;
            string pass=PassUser.TxtBox_M.Text;
            string ConPass = ConPassUser.TxtBox_M.Text;
            int emailCODEUSER = -97;


            if(!Regex.IsMatch(pass, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{8,32}$"))
            {
                Ispass = false;
                Error += "رمز عبور باید شامل حداقل یک حرف بزرگ و حداقل یک حرف کوچک و حداقل یک عدد و تعداد کارکتر های ان حداکثر 32 و حداقل 8 کاراکتر باشد " + "\n";
            }
            if (pass != ConPass && Ispass==true)
            {
                Error += "رمز به نادرستی تکرار شده است.دوباره بررسی کنید"+"\n";
            }


            try
            {
                emailCODEUSER = int.Parse(Emailtxt.Text);
            }
            catch (Exception ex) { Error += "کد ارسالی فقط شامل عدد میباشد" + "\n"; IsInt = false; }

            if (emailCODEUSER != Email_CodeReal && IsInt == true)
            {
                Error += "کد وارد شده با کد ایمیل تطابق ندارد.دوباره بررسی کنید.در صورت صلاحدید میتوانید با برگشتن به فرم ثبت نام کد جدیدی برای شما ارسال شود" + "\n";
            }

            if (Error == "")
            {
                //save User
                user.PassWord = pass;
                PerviousForm.All_Users.Add(user);
                string json_save = JsonConvert.SerializeObject(PerviousForm.All_Users,Formatting.Indented);
                string path = @"CC:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\User\All_Users.json";
                File.WriteAllText(path,json_save);
                //end Save USer
                MessageBox.Show("Done!", "GoodNews", MessageBoxButton.OK, MessageBoxImage.Information);
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                clodeAUTO++;
                this.Close();
            }
            else
            {
            matinLabel:
                MessageBoxResult a = MessageBox.Show(Error + "ردیفه؟", "UNVALID INPUT", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (a == MessageBoxResult.Yes) { return; }
                if (a == MessageBoxResult.No) { goto matinLabel; }
            }

        }



        private void Window_Closed_2(object sender, EventArgs e)
        {
            if (clodeAUTO == 0)
            {
                this.PerviousForm.Show();
            }
            //Application.Current.Shutdown();

        }
    }
}
