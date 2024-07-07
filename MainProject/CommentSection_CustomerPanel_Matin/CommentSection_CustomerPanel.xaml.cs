using MainProject.Public_Classes;
using MainProject.reserrveORorderFoods_CustomerPage_Matin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace MainProject.CommentSection_CustomerPanel_Matin
{
    /// <summary>
    /// Interaction logic for CommentSection_CustomerPanel.xaml
    /// </summary>
    /// 
    public class CommentForNow
    {
        static public CommentForNow CAST(FoodComment c, CommentSection_CustomerPanel thiss)
        {
            CommentForNow X = new CommentForNow();

            Food_Point? demo = Food_Point.FindFoodPointFromJSON(thiss.CurrentFood.FoodID,c.User_UserName);
            if (demo == null) { X.FPoint = null;/*MessageBox.Show("This is");*/ }
            else { X.FPoint = demo.Point; }

            X.fffstingPoint = $"FoodPoint : {X.FPoint}";

            X.CommnetID = c.CommentID;
            X.ContetnComment = c.Content;
            X.IsEdit = c.ISedit;
            X.fffstingEDIT = X.IsEdit == true ? "Edited" : "";


            X.Title = c.Title;
            X.TitleUI = $"UserName : {c.User_UserName} *** Title : {c.Title}";
            X.userName = c.User_UserName;
            if (c.Reply == null)
            {
                X.Reply = null;
                return X;
            }
            X.Reply = new ObservableCollection<CommentForNow>();
            foreach (FoodComment fc in c.Reply)
            {
                X.Reply.Add(CommentForNow.CAST(fc.cCloneComment(), thiss));
            }
            return X;
        }
        
        static public List<FoodComment> CAST_CLONE(ObservableCollection<CommentForNow> thiiiis)
        {
            List<FoodComment> NEW = new List<FoodComment>();
            foreach(CommentForNow a in thiiiis)
            {
                FoodComment demo = new FoodComment();
                demo.CommentID=a.CommnetID;
                demo.User_UserName=a.userName;
                demo.Content = a.ContetnComment;
                demo.Title = a.Title;
                demo.ISedit = a.IsEdit;
                demo.Reply = new List<FoodComment?>();
                if (a.Reply == null) { NEW.Add(demo); continue; }
                foreach(CommentForNow rep in a.Reply)
                {
                    FoodComment ddd = new FoodComment();
                    ddd.CommentID = rep.CommnetID;
                    ddd.User_UserName = rep.userName;
                    ddd.Content = rep.ContetnComment;
                    ddd.Title = rep.Title;
                    ddd.ISedit = rep.IsEdit;
                    ddd.Reply = null;
                }
                NEW.Add(demo);
            }




            return NEW;
        }
        public string userName { get; set; }
        public string Title { get; set; }
        public string ContetnComment { get; set; }
        public int CommnetID { get; set; }
        public ObservableCollection<CommentForNow>? Reply { get; set; }
        public bool IsEdit { get; set; }
        public string TitleUI { get; set; }
        public double? FPoint { get; set; }
        public string fffstingPoint { get; set; }
        public string fffstingEDIT { get; set; }


        public CommentForNow() { }

        //public ObservableCollection<CommentForNow>? Ifnullreturn(List<FoodComment>? comments) 
        //{
        //    if (comments == null) { return null; }
        //    List<FoodComment> a = (List<FoodComment>)comments;
        //    //return new ObservableCollection<FoodComment;
        //}


    }


    public partial class CommentSection_CustomerPanel : Window
    {
        bool Must_OFF;

        public CommentForNow? SelectedComment {  get; set; }
        public FoodClass CurrentFood {  get; set; }
        public Restaurant CurrentRestaurant { get; set; }
        public User CurrentUser { get; set; }
        public ObservableCollection<CommentForNow>? CommentTree { get; set; }
        public List<FoodComment>? AllCOM { get; set; }


        public CommentSection_CustomerPanel(FoodClass CurrentFood , Restaurant CurrentRestaurant , User CurrntUser)
        {
            InitializeComponent();
            Must_OFF = true;
            if (CurrentFood.comments_IN_ORDER == null) CurrentFood.comments_IN_ORDER = new List<FoodComment>();
            this.CurrentFood= CurrentFood;
            this.CurrentRestaurant= CurrentRestaurant;
            this.CurrentUser = CurrntUser;
            SelectedComment = null; 
            //MessageBox.Show(a.Count().ToString());
            this.CommentTree = new ObservableCollection<CommentForNow>(CurrentFood.comments_IN_ORDER.Select(c => CommentForNow.CAST(c,this)).ToList());
            //MessageBox.Show(CommentTree.Count().ToString());
            CommentTreeView.ItemsSource = this.CommentTree;
            this.DataContext = this;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveBeforeClose();
           if(Must_OFF) Application.Current.Shutdown();

        }

        private void REPbbb(object sender, RoutedEventArgs e)
        {
            if (SelectedComment == null) { MessageBox.Show("First Enter Select a Comment"); return; }
            if (SelectedComment.Reply == null) { MessageBox.Show("You Can Just Reply Main Comments!"); return; }
            if (TitleComment.Text.Trim() == "") { MessageBox.Show("You Cant Replied Comment Without Comment Title!"); return; }
            if (ContentComment.Text.Trim() == "") { MessageBox.Show("You Cant Edit Comment Without Content Comment!"); return; }

            for (int f = 0; f < CurrentFood.comments_IN_ORDER.Count; f++)
            {
                if (CurrentFood.comments_IN_ORDER[f].CommentID == SelectedComment.CommnetID)
                {
                    FoodComment CCC = new FoodComment();
                    CCC.Title= TitleComment.Text.Trim();
                    CCC.Reply = null;
                    CCC.Content= ContentComment.Text.Trim();
                    //forNow.CommnetID=METHOD;
                    CCC.ISedit = false;
                    CCC.User_UserName = CurrentUser.UserName;
                    //CCC.TitleUI = $"UserName : {SelectedComment.userName} *** Title : {SelectedComment.Title}";
                    CurrentFood.comments_IN_ORDER[f].Reply.Add(CCC);
                    break;
                }
            }
            MessageBox.Show("Done");

            TitleComment.Clear();
            ContentComment.Clear();
            this.CommentTree.Clear();
            this.CommentTree = new ObservableCollection<CommentForNow>(CurrentFood.comments_IN_ORDER.Select(c => CommentForNow.CAST(c,this)).ToList());
            CommentTreeView.ItemsSource = this.CommentTree;
        }
        private void REmoveBBB(object sender, RoutedEventArgs e)
        {
            if (SelectedComment == null){ MessageBox.Show("First Enter Select a Comment"); return; }
            if(SelectedComment.userName!=CurrentUser.UserName) { MessageBox.Show("You Can Delete Just Own Comment!"); return; }

            for(int f=0; f<CurrentFood.comments_IN_ORDER.Count; f++)
            {
                if (CurrentFood.comments_IN_ORDER[f].CommentID == SelectedComment.CommnetID)
                {
                    CurrentFood.comments_IN_ORDER.RemoveAt(f);
                    break;
                }
                else
                {
                    for(int d=0; d< CurrentFood.comments_IN_ORDER[f].Reply.Count; d++)
                    {
                        if (CurrentFood.comments_IN_ORDER[f].Reply[d].CommentID == SelectedComment.CommnetID)
                        {
                            CurrentFood.comments_IN_ORDER[f].Reply.RemoveAt(d);
                            break;
                        }
                    }
                }
            }


            MessageBox.Show("Done");
            this.CommentTree.Clear();
            this.CommentTree = new ObservableCollection<CommentForNow>(CurrentFood.comments_IN_ORDER.Select(c => CommentForNow.CAST(c,this)).ToList());
            CommentTreeView.ItemsSource = this.CommentTree;
        }

        private void SAVEpoint(object sender, RoutedEventArgs e)
        {
            if (PointTTTT.Text.Trim() == "")
            {
                MessageBox.Show("First Insert a Point");return;
            }
            double pp;
            try
            {
                pp=double.Parse(PointTTTT.Text.Trim());
                if(pp < 0 || pp > 10) { throw new Exception(""); }
            }
            catch
            {
                MessageBox.Show("Type Correct FoodPoint\nFoodPoint MUST BE in [0,10]");return;
            }

            List<Food_Point> All = JsonConvert.DeserializeObject<List<Food_Point>>(File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Points\All_Points.json"));
            int f = 0;
            int flag = 0;
            foreach (Food_Point fff in All)
            {
                if (fff.FoodID == CurrentFood.FoodID && fff.UserName == CurrentUser.UserName)
                {
                    //return fff;
                    flag++;
                    break;
                }
                f++;
            }
            
            if (flag == 0) { Food_Point matin = new Food_Point();matin.Point = pp;matin.UserName = CurrentUser.UserName;matin.FoodID = CurrentFood.FoodID; All.Add(matin); }
            else { All[f].Point = pp; }

            File.WriteAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Points\All_Points.json",
                JsonConvert.SerializeObject(All, Formatting.Indented));

            PointTTTT.Clear();
            MessageBox.Show("Done");
            this.CommentTree.Clear();
            this.CommentTree = new ObservableCollection<CommentForNow>(CurrentFood.comments_IN_ORDER.Select(c => CommentForNow.CAST(c,this)).ToList());
            CommentTreeView.ItemsSource = this.CommentTree;
        }

        private void EDITbbb(object sender, RoutedEventArgs e)
        {
            if (SelectedComment == null) { MessageBox.Show("First Enter Select a Comment"); return; }
            if (SelectedComment.userName != CurrentUser.UserName) { MessageBox.Show("You Can Edit Just Own Comment!"); return; }
            if (TitleComment.Text.Trim() == "") { MessageBox.Show("You Cant Edit Comment Without Comment Title!"); return; }
            if (ContentComment.Text.Trim() == "") { MessageBox.Show("You Cant Edit Comment Without Content Comment!"); return; }

            for (int f = 0; f < CurrentFood.comments_IN_ORDER.Count; f++)
            {
                if (CurrentFood.comments_IN_ORDER[f].CommentID == SelectedComment.CommnetID)
                {
                    CurrentFood.comments_IN_ORDER[f].Content = ContentComment.Text.Trim();
                    CurrentFood.comments_IN_ORDER[f].Title = TitleComment.Text.Trim();
                    CurrentFood.comments_IN_ORDER[f].ISedit = true;
                    break;
                }
                else
                {
                    for (int d = 0; d < CurrentFood.comments_IN_ORDER[f].Reply.Count; d++)
                    {
                        if (CurrentFood.comments_IN_ORDER[f].Reply[d].CommentID == SelectedComment.CommnetID)
                        {
                            CurrentFood.comments_IN_ORDER[f].Reply[d].Content= ContentComment.Text.Trim();
                            CurrentFood.comments_IN_ORDER[f].Reply[d].Title = TitleComment.Text.Trim();
                            CurrentFood.comments_IN_ORDER[f].Reply[d].ISedit = true;
                            break;
                        }
                    }
                }
            }
            MessageBox.Show("Done");
            ContentComment.Clear();
            TitleComment.Clear();
            this.CommentTree.Clear();
            this.CommentTree = new ObservableCollection<CommentForNow>(CurrentFood.comments_IN_ORDER.Select(c => CommentForNow.CAST(c,this)).ToList());
            CommentTreeView.ItemsSource = this.CommentTree;
        }

        private void CommentTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
             SelectedComment = e.NewValue as CommentForNow;
            //MessageBox.Show(SelectedComment.Title);
        }

        private void ADDbbb(object sender, RoutedEventArgs e)
        {
            if (SelectedComment != null) { MessageBox.Show("First Free Selected "); return; }


            if (TitleComment.Text.Trim() == "") { MessageBox.Show("You Cant Add Comment Without Comment Title!"); return; }
            if (ContentComment.Text.Trim() == "") { MessageBox.Show("You Cant Add Comment Without Content Comment!"); return; }

                    FoodComment CCC = new FoodComment();
                    CCC.Title = TitleComment.Text.Trim();
                    CCC.Reply = new List<FoodComment?>();
                    CCC.Content = ContentComment.Text.Trim();
                    //forNow.CommnetID=METHOD;
                    CCC.ISedit = false;
                    CCC.User_UserName = CurrentUser.UserName;
                    //CCC.TitleUI = $"UserName : {SelectedComment.userName} *** Title : {SelectedComment.Title}";
                    CurrentFood.comments_IN_ORDER.Add(CCC);
            MessageBox.Show("Done");
            ContentComment.Clear();
            TitleComment.Clear();
            this.CommentTree.Clear();
            this.CommentTree = new ObservableCollection<CommentForNow>(CurrentFood.comments_IN_ORDER.Select(c => CommentForNow.CAST(c,this)).ToList());
            CommentTreeView.ItemsSource = this.CommentTree;
        }

        private void FreeSel(object sender, RoutedEventArgs e)
        {
            SelectedComment = null;
            if (CommentTreeView.SelectedItem != null)
            {
                TreeViewItem item = (TreeViewItem)CommentTreeView.ItemContainerGenerator.ContainerFromItem(CommentTreeView.SelectedItem);
                DeselectTreeViewItem(item);
            }
        }
        private void DeselectTreeViewItem(TreeViewItem item)
        {
            if (item != null)
            {
                item.IsSelected = false;

                // Reset the focus to remove the highlight
                if (item.IsFocused)
                {
                    item.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }
            }
        }

        private void DelPPP(object sender, RoutedEventArgs e)
        {

                List<Food_Point> All = JsonConvert.DeserializeObject<List<Food_Point>>(File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Points\All_Points.json"));
            int f = 0;
            int flag = 0;
            foreach (Food_Point fff in All)
                {
                    if (fff.FoodID == CurrentFood.FoodID && fff.UserName==CurrentUser.UserName)
                    {
                    //return fff;
                    flag++;
                    break;
                    }
                    f++;
                }
            if(flag == 0) { MessageBox.Show("You HaveNot Enter FoodPoint YET!");return; }
            All.RemoveAt(f);
            File.WriteAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Points\All_Points.json",
                JsonConvert.SerializeObject(All,Formatting.Indented));
            MessageBox.Show("Done");
            this.CommentTree.Clear();
            this.CommentTree = new ObservableCollection<CommentForNow>(CurrentFood.comments_IN_ORDER.Select(c => CommentForNow.CAST(c, this)).ToList());
            CommentTreeView.ItemsSource = this.CommentTree;
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            SaveBeforeClose();
            reserrveORorderFoods_CustomerPage reserrveORorderFoods_CustomerPage = new reserrveORorderFoods_CustomerPage(this.CurrentUser, this.CurrentRestaurant);
            reserrveORorderFoods_CustomerPage.Show();
            //MessageBox.Show(CurrentUser.UserName);
            Must_OFF = false;
            this.Close();

        }
        private void SaveBeforeClose()
        {

            //all hich


            //food commnet cuuren food
            List<Restaurant> allres = JsonConvert.DeserializeObject<List<Restaurant>>(File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Restaurant\All_Restaurant.json"));
            for (int i = 0; i < allres.Count; i++)
            {
                if (allres[i].UserName == CurrentRestaurant.UserName)
                {
                    for (int j = 0; j < allres[i].Menu.Count; j++)
                    {
                        if (allres[i].Menu[j].Name == CurrentFood.FoodCategory)
                        {
                            for (int k = 0; k < allres[i].Menu[j].Foods.Count; k++)
                            {
                                if (allres[i].Menu[j].Foods[k].FoodID == CurrentFood.FoodID)
                                {
                                    allres[i].Menu[j].Foods[k].comments_IN_ORDER.Clear();
                                    allres[i].Menu[j].Foods[k].comments_IN_ORDER = CommentForNow.CAST_CLONE(CommentTree);

                                }
                                break;
                            }
                        }
                        break;
                    }
                }
                break;
            }
            File.WriteAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Restaurant\All_Restaurant.json",
                JsonConvert.SerializeObject(allres, Formatting.Indented));
            //reserrveORorderFoods_CustomerPage reserrveORorderFoods_CustomerPage = new reserrveORorderFoods_CustomerPage(this.CurrentUser,this.CurrentRestaurant);
            //reserrveORorderFoods_CustomerPage.Show();
        }
    }
}
