using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Public_Classes
{
    internal class Comment
    {
        public string Title {  get; set; }
        public string Content { get; set; }
        public int CommentID {  get; set; }
        public string User_UserName { get; set; }
        Comment? Reply;
        public Comment() { }
         public Comment(string title, string content, int commentID, Comment? reply,string User_UserName) 
        {
            Title = title;
            Content = content;
            CommentID = commentID;
            Reply = reply;
            this.User_UserName = User_UserName;
        }
    }
}
