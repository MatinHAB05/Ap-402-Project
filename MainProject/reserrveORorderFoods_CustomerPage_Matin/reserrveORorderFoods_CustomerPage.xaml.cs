using MainProject.CustomerMainPage_Parham.CustomerMainPage;
using MainProject.Public_Classes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using MimeKit;
using MailKit.Net.Smtp;
using Newtonsoft.Json;
using System.IO;
using MainProject.CommentSection_CustomerPanel_Matin;

namespace MainProject.reserrveORorderFoods_CustomerPage_Matin
{
    /// <summary>
    /// Interaction logic for reserrveORorderFoods_CustomerPage.xaml
    /// </summary>
    public partial class reserrveORorderFoods_CustomerPage : Window, INotifyPropertyChanged
    {
        bool Must_OFF;

        public User CurrentUser { get; set; }
        public Restaurant CurrentREStaurant { get; set; }
        public ObservableCollection<Category> _categories { get; set; }
        public ObservableCollection<FoodClass> _selectedFoods { get; set; }
        public ICommand RemoveFoodCommand { get; private set; }
        public ICommand CommentFUN { get; private set; }
        public ICommand FullScreenIMG { get; private set; }


        public ICommand FUN { get; private set; }
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Categories")); }
        }
        public ObservableCollection<Category> First {  get; set; }
        public ObservableCollection<Category> Demo { get; set; }

        public ObservableCollection<FoodClass> SelectedFoods
        {
            get { return _selectedFoods; }
            set { _selectedFoods = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedFoods")); }
        }
        //public
        public reserrveORorderFoods_CustomerPage(User CurUser , Restaurant CurRes)
        {
            InitializeComponent();
            Must_OFF = true;
            this.DataContext = this;
            MainListView.Visibility = Visibility.Hidden;
            CurrentUser = CurUser;
            CurrentREStaurant= CurRes;
            //if(resturants has OK)
            //radioButton1.Visibility = Visibility.Hidden;
            Categories = new ObservableCollection<Category>( CurRes.Menu);

            SelectedFoods = new ObservableCollection<FoodClass>();

            FUN = new RelayCommand<FoodClass>(AddToSelectedFoods);

            CommentFUN=new RelayCommand<FoodClass>(CommnetSection);

            RemoveFoodCommand = new RelayCommand<FoodClass>(RemoveFromSelectedFoods);
            FullScreenIMG = new RelayCommand<FoodClass>(FullIMAGE);

            First = new ObservableCollection<Category>();
            foreach(Category c in Categories) { First.Add(c.cClone());}

            Demo = new ObservableCollection<Category>();
            foreach (Category c in Categories) { Demo.Add(c.cClone()); }

            CategoryLIST_VIEW.ItemsSource = Categories;


            if (CurrentREStaurant.IsCanReserve==false)
            {
                reserve.Visibility = Visibility.Hidden;
            }
        }
        private void AddToSelectedFoods(FoodClass food)
        {
            if (food.RemNumber <= 0) { MessageBox.Show($"{food.Name} is over!","Attention",MessageBoxButton.OK,MessageBoxImage.Warning); return; }
            SelectedFoods.Add(food);
            food.RemNumber--;

            Demo = new ObservableCollection<Category>();
            foreach (Category c in Categories) { Demo.Add(c.cClone()); }
            Categories.Clear();
            foreach (Category c in Demo) { Categories.Add(c.cClone()); }
            
            CategoryLIST_VIEW.ItemsSource = Categories;
            

            MainListView.Visibility = Visibility.Visible;

        }
        private void FullIMAGE(FoodClass food)
        {
            bool HaveImage=true;
            if(food.Image_Path == null || food.Image_Path=="") { HaveImage = false; }
           Window1 demo = new Window1(food.Image_Path.Trim(),HaveImage,this); demo.Show();
            this.Hide();

        }
        private void RemoveFromSelectedFoods(FoodClass food)
        {
            SelectedFoods.Remove(food);
            //food.RemNumber++;
            foreach(Category Cat in Categories)
            {
                if (Cat.Name == food.FoodCategory)
                {
                    foreach(FoodClass fc in Cat.Foods)
                    {
                        if(fc.Name == food.Name && fc.FoodID == food.FoodID)
                        {
                            fc.RemNumber++;
                            break;
                        }
                    }
                    break;
                }
            }

            Demo = new ObservableCollection<Category>();
            foreach (Category c in Categories) { Demo.Add(c.cClone()); }
            Categories.Clear();
            foreach (Category c in Demo) { Categories.Add(c.cClone()); }

            CategoryLIST_VIEW.ItemsSource = Categories;
            

            if (MainListView.Items.Count == 0)
            {
                MainListView.Visibility = Visibility.Hidden;

            }
        }

        private void CommnetSection(FoodClass food)
        {
            //MessageBox.Show("HI MATIN");
            CommentSection_CustomerPanel commentSection_CustomerPanel = new CommentSection_CustomerPanel(food,CurrentREStaurant,CurrentUser);
            commentSection_CustomerPanel.Show();
            Must_OFF = false;
            this.Close();
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


        private void AddToList(FoodClass food)
        {
            MessageBox.Show($"{food.Name},{food.price}.{food.xBar}");
        }

        private void CommentSection(object sender, RoutedEventArgs e)
        {

        }

        private void Pay_Button(object sender, RoutedEventArgs e)
        {
            bool IsReserve = false;
            bool IScash = true;
            string Error = "";

            if (cash.IsChecked == true) { IScash = true; }
            else if (cash.IsChecked == false) { IScash = false; }
            else
            {
                Error +="نوع پرداخت هزینه مشخص نشده است" + "\n";

            }


            if (reserve.Visibility == Visibility.Hidden) 
            {
                if (order.IsChecked==true)
                {
                    IsReserve = false;
                }
                else
                {
                   Error+="نوع درخواست غدا مشخص نشده است" +"\n";
                }            
            }
            else
            {
                if (order.IsChecked == true)
                {
                    IsReserve = false;
                }
                else if (reserve.IsChecked == true)
                {
                    IsReserve = true;
                }
                else
                {
                    Error += "نوع درخواست غدا مشخص نشده است"+"\n";
                }
            }


            if(Error!="")
            {
            matinLabel:
                MessageBoxResult a = MessageBox.Show(Error + "ردیفه؟", "UNVALID INPUT", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (a == MessageBoxResult.Yes) { return; }
                if (a == MessageBoxResult.No) { goto matinLabel; }
            }

            RequestType requestType=RequestType.Cash_Order;
            if      (IScash && IsReserve) { requestType=RequestType.Cash_Reserve; }
            else if (IScash && !IsReserve) { requestType = RequestType.Cash_Order; }
            else if (!IScash && IsReserve) { requestType = RequestType.Online_Reserve; }
            else if (!IScash && !IsReserve) { requestType = RequestType.Online_Order; }

            //save in File
            List<FoodRequest> New = SelectedFoods.Select(f => new FoodRequest
            {
                FoodID = f.FoodID,
                User_UserName=CurrentUser.UserName,
                RestaurantUserName = CurrentREStaurant.UserName,
                RequestType = requestType,
                RequestID = FoodRequest.GetRANDOM()
            }).ToList();
            List<FoodRequest> all = JsonConvert.DeserializeObject<List<FoodRequest>>(File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\FoodRequest\All_FoodRequest.json"));
            all.AddRange(New);
            File.WriteAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\FoodRequest\All_FoodRequest.json", 
                JsonConvert.SerializeObject(all,Formatting.Indented));
            //end save in File***

            MessageBox.Show(New.Count().ToString());
            if (requestType == RequestType.Online_Order || requestType == RequestType.Online_Reserve) 
            {

                //send email
                string txt = $"Hello, we are {CurrentREStaurant.RestaurantName}<br>You have just placed an order from our restaurant as follows:<br>" +

                  MessageEMAIL(New) +

                    "<br>we hope you enjoy your meal!";

                SendEmail("demobazi72@gmail.com", CurrentREStaurant.RestaurantName, CurrentUser.Name+CurrentUser.LastName, CurrentUser.Email_Unique, "Online Purchase Receipt", txt, "ddoduwbsvufdspse");

                //end send email




            }
            SelectedFoods.Clear();

        }
        private string MessageEMAIL(List<FoodRequest> New)
        {
            string mess = "";
            int i = 1;
            foreach (FoodRequest f in New)
            {
                string nnn = "";
                if (f.RequestType == RequestType.Online_Reserve) nnn = ".Online_Reserve";
                    if (f.RequestType == RequestType.Online_Order) nnn = "Online_Order";
                if (f.RequestType == RequestType.Cash_Reserve) nnn = "Cash_Reserve";
                if (f.RequestType == RequestType.Cash_Order) nnn = "Cash_Order";

                mess += $"<b>{i}-- FoodID : {f.FoodID}  , User Name {CurrentUser.UserName} , Restaurant Name : {Restaurant.GetFromUserName(CurrentREStaurant.UserName).RestaurantName} , Request Type : {nnn} , Request ID : {f.RequestID} , Food Name : {( (FoodClass)Restaurant.Get_Food_FromFoodID(f.FoodID,CurrentREStaurant) ).Name} , Food Price : {Restaurant.Get_Food_FromFoodID(f.FoodID,CurrentREStaurant).price}" + "<br> </b>";
                i++;
            }
            return mess;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            SaveBeforeClose();
          if(Must_OFF)  Application.Current.Shutdown();

        }

        private void SendEmail(string emailMabda, string NameSender, string NameReciver, string emailMaghsad, string Subject, string ContentTExt, string passwordEmailMabda)
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

        private void BackPage(object sender, RoutedEventArgs e)
        {
            SaveBeforeClose();
            CustomerMainPage back = new CustomerMainPage(CurrentUser);
            back.Show();
            Must_OFF = false;
            this.Close();

        }
        private void SaveBeforeClose()
        {
            List<Restaurant> all = JsonConvert.DeserializeObject<List<Restaurant>>(File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Restaurant\All_Restaurant.json"));
            int d = 0;
            foreach (Restaurant r in all)
            {
                if (r.UserName == CurrentREStaurant.UserName)
                {
                    all[d].Menu.Clear();
                    foreach (Category cat in Categories)
                    {
                        all[d].Menu.Add(cat.cClone());
                    }
                    break;
                }
                d++;
            }
            File.WriteAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Restaurant\All_Restaurant.json",
                JsonConvert.SerializeObject(all, Formatting.Indented));
            //CustomerMainPage customerMainPage = new CustomerMainPage(CurrentUser);
            //customerMainPage.Show();
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

