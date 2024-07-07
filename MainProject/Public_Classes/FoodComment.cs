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
            Title = title;
            Content = content;
            Reply = reply;
            this.User_UserName = User_UserName;
            string json = File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\Restaurant\All_Restaurant.json");
            List<Restaurant> restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);
            int numberOfFoodComments = 0;
            foreach (Restaurant re in restaurants)
            {
                foreach (Category category in re.Menu)
                {
                    foreach (FoodClass food in category.Foods)
                    {
                        foreach(FoodComment fc in food.comments_IN_ORDER)
                        {
                            numberOfFoodComments += fc.Reply.Count();
                            numberOfFoodComments += 1;
                        }
                    }
                }
            }
            CommentID = numberOfFoodComments + 1;
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
    }

}
