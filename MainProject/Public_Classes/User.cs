using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Public_Classes
{
    internal class User
    {
        public string UserName {  get; set; }
        public int UserID {  get; set; }
        public string Name {  get; set; }
        public string LastName {  get; set; }
        public string Email_Unique { get; set; }
        public string PassWord {  get; set; }
        public string Phone {  get; set; }
        public string Address {  get; set; }
        public Gender Gender { get; set; }
        public List<Food_Point>? PointsList { get; set; }


        public User(string UserName ,int UserID , string  Name , string LastName , string Email_Unique , string Password , string Phone , string Address , Gender Gender)
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
            this.PointsList = null;
        }




    }
}
