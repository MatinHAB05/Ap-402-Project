using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Public_Classes
{
    public class User
    {
        public CustomerType customerType = CustomerType.Bronze;
        public string UserName {  get; set; }
        public int UserID {  get; set; }
        public string Name {  get; set; }
        public string LastName {  get; set; }
        public string Email_Unique { get; set; }
        public string PassWord {  get; set; }
        public string Phone {  get; set; }
        public string Address {  get; set; }
        public Gender Gender { get; set; }
        public User() { }
        public User(string UserName ,int UserID , string  Name , string LastName , string Email_Unique , string Password , string Phone , string Address , Gender Gender,CustomerType customerType)
        {
            this.UserName = UserName;
            this.UserID = UserID;
            this.Name = Name;
            this.LastName = LastName;
            this.Email_Unique = Email_Unique;
            this.PassWord= Password; ;
            this.Phone = Phone;
            this.Address = Address;
            this.Gender = Gender;
            this.customerType = customerType;
        }
        public User(string UserName, string Name, string LastName, string Email_Unique, string Phone)
        {//Matin
            this.Email_Unique= Email_Unique;
            this.UserName = UserName;   
            this.LastName = LastName;   
            this.Name = Name;   this.Phone = Phone; 
        }
        static public string? GetFIRSTNAMEfromjson(string UserName) 
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\User\All_Users.json"));
            
            foreach(User u in users)
            {
                if(u.UserName == UserName)
                {
                    return u.Name;
                }
            }
            return null;
        
        
        }
        static public string? GetLASTNAMEfromjson(string UserName)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\User\All_Users.json"));

            foreach (User u in users)
            {
                if (u.UserName == UserName)
                {
                    return u.LastName;
                }
            }
            return null;


        }

    }
}
