using MailKit.Net.Smtp;
using RestaurantApp.Public_Classes;
using RestaurantApp.SetPassWordPage_Matin;
using MimeKit;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace RestaurantApp.SignInPage_Matin
{
    /// <summary>
    /// Interaction logic for SignInForm.xaml
    /// </summary>
    public partial class SignInForm : Window
    {
        bool Must_OFF;

        internal List<User> All_Users;
        internal List<Admin> All_Admin;
        internal List<Restaurant> All_Restaurants;
        internal SignInForm(List<User> All_Us , List<Restaurant> restaurants , List<Admin> admins )
        {
            InitializeComponent();
            Must_OFF= true;
            All_Users = All_Us;
            All_Admin = admins;
            All_Restaurants = restaurants;
            //mamad.Width = 200;
            FirstNametxt.ImageVAr.Width = 38;
            //mamad.RecaVar.Width = 60;
            FirstNametxt.txtBox.Width = 176;
            All_Users= All_Us;
        }
        private void SendEmail(string emailMabda , string NameSender , string NameReciver,string emailMaghsad,string Subject,string ContentTExt,string passwordEmailMabda)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress(NameSender, emailMabda));
            email.To.Add(new MailboxAddress(NameReciver, emailMaghsad));

            email.Subject = Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = ContentTExt  //Text = "<b>Hello all the way from the land of C#</b>"
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate(emailMabda, passwordEmailMabda); //"ddoduwbsvufdspse"

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = UserNametxt.txtBox.Text.Trim();
            string firstName = FirstNametxt.txtBox.Text.Trim();
            string LastName = LastNametxt.Text.Trim();
            string Email = emailtxt.txtBox.Text.Trim();
            string phone = phonetxt.txtBox.Text.Trim();
            string FULLname = firstName + " " + LastName;
            string Error = "";
            bool Isphone = true;
            bool IsUserName = true;
            string Rule = "";
            if (!Regex.IsMatch(username, @"^[A-Za-z0-9]{3,}$"))
            {
                Error += "نام کاربری فقط شامل اعداد و حروف کوچک و بزرگ انگلیسی متشکل از حداقل 3 حرف باید باشد" + "\n";
                IsUserName = false;
            }

            if (!Regex.IsMatch(FULLname, @"^[A-Za-z]{3,32} [A-Za-z]{3,32}$"))
            {
                Error += "اسم باید شامل حداقل 3 و حداکثر 32 حرف باشد و اعداد و کارکتر های نگارشی مورد قبول نیست" + "\n";
            }

            if (!Regex.IsMatch(Email, @"^[A-Z0-9a-z_]{3,32}\@[A-Za-z]{3,32}\.[A-Za-z]{2,3}$"))
            {
                Error += "ادرس ایمیل شما ناشناخته میباشد" + "\n";

            }

            if (!Regex.IsMatch(phone, @"^09\d{9}$"))
            {
                Error += "فقط شماره های تلفنی شناخته شده در ایران مورد قبول میباشد" + "\n";
                Isphone = false;
            }

            //***************************
            bool isKharab = false;
            foreach (User u in All_Users)
            {
                if (u.Phone == phone && Isphone == true)
                {
                    Error += "این شماره موبایل ثبت شده است" + "\n";
                    isKharab = true;
                }
                if (u.UserName == username & IsUserName == true)
                {
                    Error += "این نام کاربری ثبت شده است" + "\n";
                    isKharab = true;

                }
            }

            if (!isKharab)
            {
                foreach (Restaurant r in All_Restaurants)
                {

                    if (r.UserName == username & IsUserName == true)
                    {
                        Error += "این نام کاربری ثبت شده است" + "\n";
                        isKharab = true;

                    }
                }
            }
            if (!isKharab) { 
            foreach (Admin a in All_Admin)
            {

                if (a.UserName == username & IsUserName == true)
                {
                    Error += "این نام کاربری ثبت شده است" + "\n";
                    isKharab = true;

                }
            }
        }
            //***************************

            if (Error == "")
            {
                //write

                User user = new User(username, firstName, LastName, Email, phone);
                user.Address = "";
                if (MMale.IsChecked==true)
                {
                    user.Gender = Gender.Male;
                }
                else
                {
                    user.Gender=Gender.Female;
                }
                //end write

                //send email code
                int emailCode = new Random().Next(100000, 999999);

                string TEXTemailDemo = "Hi This is \"MatinOOParham\".<br>"+$"{FULLname} recently signed up for our program!!<br>To confirm your registration, just enter the code below along with the appropriate password in the designated places in the open form...<br>Hope you enjoy our program<br><b>Email Code : "+emailCode+" </b>";

                SendEmail("demobazi72@gmail.com", "The MatinOOParham Restaurant", FULLname, Email, "Confrim SignUp", TEXTemailDemo, "ddoduwbsvufdspse");

                //end send email code

                SetPassWordForm form = new SetPassWordForm(user, this, emailCode);
                form.Show();

                //LoginPage login = new LoginPage();
                //login.Show();

                this.Hide();
                return;
            }
            else
            {
            matinLabel:
                MessageBoxResult a = MessageBox.Show(Error+"ردیفه؟", "UNVALID INPUT", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (a == MessageBoxResult.Yes) { return; }
                if (a == MessageBoxResult.No) { goto matinLabel ; }
            }
        }



        private List<Restaurant>? GetAllRes(string path)
        {
            return JsonConvert.DeserializeObject<List<Restaurant>>(File.ReadAllText(path));
        }
        private List<User>? GetAllUser(string path)
        {
            return JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(path));
        }
        private List<Admin>? GetAllAdmin(string path)
        {
            return JsonConvert.DeserializeObject<List<Admin>>(File.ReadAllText(path));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           if(Must_OFF) Application.Current.Shutdown();

        }
    }
}
