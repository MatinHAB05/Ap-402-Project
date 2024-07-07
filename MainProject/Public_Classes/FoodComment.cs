using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Text.Json;

namespace MainProject.Public_Classes
{
    public class FoodComment
    {
        public string Title {  get; set; }
        public string Content { get; set; }
        public int CommentID {  get; set; }
        public string User_UserName { get; set; }
      
      
        public bool ISedit = false;

        public List<FoodComment?>? Reply;
        public FoodComment() { }
         public FoodComment(string title, string content, int commentID, List<FoodComment>? reply,string User_UserName) 
        {
            Title = title;
            Content = content;
            CommentID = commentID;
            Reply = reply;
            this.User_UserName = User_UserName;
        }
        public FoodComment(string title, string content, List<FoodComment?>? reply, string User_UserName)
        {
            this.Title = title;
            this.Content = content;
            this.Reply = reply;
            this.User_UserName = User_UserName;
            string json = File.ReadAllText(MainWindow.Get_Dir_ALL_RESTAURANT_json());
            List<Restaurant> restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);
            int numberOfFoodComments = 0;
            this.CommentID = 572;
        }
        public FoodComment cCloneComment()
        {

            FoodComment comment = new FoodComment();
            comment.Title = this.Title;
            comment.Content = this.Content;
            comment.CommentID = this.CommentID;
            comment.User_UserName = this.User_UserName;
            if (this.Reply != null)
            {
                comment.Reply = new List<FoodComment?>();
                //MessageBox.Show("3333");
                foreach (FoodComment r in this.Reply)
                {
                    comment.Reply.Add(r.cCloneComment());

                }
            }
            else
            {
                //MessageBox.Show("asdad");

                comment.Reply = null;
            }
            //MessageBox.Show("sss");
            //MessageBox.Show ( (comment==null).ToString() );
            return comment;

        }

        static public int CommentIDgenerator_matin()
        {
            int flag;
            int rand;
            List<Restaurant> listRES = JsonConvert.DeserializeObject<List<Restaurant>>(File.ReadAllText(MainWindow.Get_Dir_ALL_RESTAURANT_json())).ToList(); 
            List<FoodComment> list = new List<FoodComment>();
            foreach(Restaurant r in listRES)
            {
                foreach(Category rs in r.Menu)
                {
                    foreach(FoodClass rsf in rs.Foods)
                    {
                        foreach(FoodComment fCOM in rsf.comments_IN_ORDER)
                        {
                            list.Add(fCOM.cCloneComment());
                        }
                    }
                }
            }

            do
            {
                flag = 0;
                rand = (new Random()).Next(100, 999999999);
                foreach (FoodComment fCOM in list)
                {
                    if (fCOM.CommentID == rand) { flag = 1; break; }
                }

            } while (flag == 1);
            return rand;
        }
    }

}
