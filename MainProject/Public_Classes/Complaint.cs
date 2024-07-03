using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Public_Classes
{
    internal class Complaint
    {
        public int ComplainID {  get; set; }
        public string ComplainText { get; set; }
        public string ComplaintTitile {  get; set; }
        public User User { get; set; }
        public Restaurant Restaurant { get; set; }
        public bool IsChecked {  get; set; }
        public Complaint() { }
        public Complaint(int complainID, string complainText, string complaintTitile, User user, Restaurant restaurant, bool isChecked)
        {
            ComplainID = complainID;
            ComplainText = complainText;
            ComplaintTitile = complaintTitile;
            User = user;
            Restaurant = restaurant;
            IsChecked = isChecked;
        }
    }
}
