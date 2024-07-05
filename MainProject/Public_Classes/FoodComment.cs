using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MainProject.Public_Classes
{
    public class FoodComment
    {
        public string Title {  get; set; }
        public string Content { get; set; }
        public int CommentID {  get; set; }
        public string User_UserName { get; set; }
        FoodComment? Reply;
        public FoodComment() { }
         public FoodComment(string title, string content, int commentID, FoodComment? reply,string User_UserName) 
        {
            Title = title;
            Content = content;
            CommentID = commentID;
            Reply = reply;
            this.User_UserName = User_UserName;
        }
        public FoodComment cCloneComment()
        {
            
            FoodComment comment = new FoodComment();
            comment.Title = this.Title;
            comment.Content = this.Content;
            comment.CommentID = this.CommentID;
            comment.User_UserName= this.User_UserName;
            if (this.Reply != null)
            {
                //MessageBox.Show("3333");

                comment.Reply = this.Reply.cCloneComment();
            }
            else
            {
                //MessageBox.Show("asdad");

                comment.Reply= null;
            }
            //MessageBox.Show("sss");
            //MessageBox.Show ( (comment==null).ToString() );
            return comment;

        }
    }

}
