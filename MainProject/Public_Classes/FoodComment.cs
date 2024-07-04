using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            comment.Title = Title;
            comment.Content = Content;
            comment.CommentID = CommentID;
            comment.User_UserName= User_UserName;
            if (Reply != null)
            {
                comment.Reply = Reply.cCloneComment();
            }
            else
            {
                comment.Reply= null;
            }
            return comment;
        }
    }

}
