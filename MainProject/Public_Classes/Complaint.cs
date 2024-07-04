using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Public_Classes
{
    public class Complaint
    {
        public int ComplainID {  get; set; }
        public string ComplainText { get; set; }
        public string ComplaintTitile {  get; set; }
        public string User_UserName { get; set; }
        public string RestaurantUserName { get; set; }
        public bool IsChecked {  get; set; }
        public Complaint() { }
        public Complaint(int complainID, string complainText, string complaintTitile, string User_UserName, string RestaurantUserName, bool isChecked)
        {
            ComplainID = complainID;
            ComplainText = complainText;
            ComplaintTitile = complaintTitile;
            this.RestaurantUserName = RestaurantUserName;
            this.User_UserName = User_UserName;
            IsChecked = isChecked;
        }
    }
}
