using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Public_Classes
{
    public class ReceptionComment
    {
        public string Title {  get; set; }
        public string Content { get; set; }
        public int CommentID {  get; set; }
        public string User_UserName { get; set; }
        public int RequestID {  get; set; }

        public ReceptionComment() { }
         public ReceptionComment(string title, string content, int commentID,string User_UserName) 
        {
            Title = title;
            Content = content;
            CommentID = commentID;
            this.User_UserName = User_UserName;
        }
        public ReceptionComment cCloneComment()
        {
            ReceptionComment comment = new ReceptionComment();
            comment.Title = Title;
            comment.Content = Content;
            comment.CommentID = CommentID;
            comment.User_UserName= User_UserName;
            comment.RequestID = RequestID;

            return comment;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Public_Classes
{
    public class ReceptionComment
    {
        public string Title {  get; set; }
        public string Content { get; set; }
        public int CommentID {  get; set; }
        public string User_UserName { get; set; }
        public int RequestID {  get; set; }

        public ReceptionComment() { }
         public ReceptionComment(string title, string content, int commentID,string User_UserName) 
        {
            Title = title;
            Content = content;
            CommentID = commentID;
            this.User_UserName = User_UserName;
        }
        public ReceptionComment cCloneComment()
        {
            ReceptionComment comment = new ReceptionComment();
            comment.Title = Title;
            comment.Content = Content;
            comment.CommentID = CommentID;
            comment.User_UserName= User_UserName;
            comment.RequestID = RequestID;

            return comment;
        }
    }

}
