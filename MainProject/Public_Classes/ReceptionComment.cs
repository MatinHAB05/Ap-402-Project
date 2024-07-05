using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
         public ReceptionComment(string title, string content, int commentID,string User_UserNam,int reqId) 
        {
            Title = title;
            Content = content;
            CommentID = commentID;
            this.RequestID = reqId;
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
        static public int RandomGenrator()
        {
            List<ReceptionComment> list = JsonConvert.DeserializeObject<List<ReceptionComment>>(File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\ReceptionComment\All_ReceptionComment.json"));
            int flag;
            int random;
            do
            {
                flag = 0;
                random =(new Random()).Next(100,1000000);
                foreach(ReceptionComment rc in list)
                {
                    if(rc.CommentID == random)
                    {
                        flag=1; break;  
                    }
                }
            } while (flag == 1);
            return random;
        }
    }

}
