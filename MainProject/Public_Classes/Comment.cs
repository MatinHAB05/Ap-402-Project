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
        public Restaurant Restaurant { get; set; }
        public FoodClass food { get; set; }
        public User User { get; set; }
        Comment? Reply;
         public Comment(string title, string content, int commentID, Comment? reply,User user , Restaurant restaurant , FoodClass food) 
        {
            Title = title;
            Content = content;
            CommentID = commentID;
            Reply = reply;
            User = user;
            Restaurant = restaurant;
            User = user;
        }
    }
}
