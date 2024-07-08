using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public string Response {  get; set; }
        public Complaint() { }
        public Complaint(int complainID, string complainText, string complaintTitile, string User_UserName, string RestaurantUserName, bool isChecked)
        {
            ComplainID = complainID;
            ComplainText = complainText;
            ComplaintTitile = complaintTitile;
            this.RestaurantUserName = RestaurantUserName;
            this.User_UserName = User_UserName;
            IsChecked = isChecked;
            Response = "";
        }
        static public int ComPlaintIDGenrator()
        {
            List<Complaint> list = JsonConvert.DeserializeObject<List<Complaint>>(File.ReadAllText(MainWindow.Get_Dir_ALL_COMPLAINTS_json()));
            int flag;
            int id;
            Random random = new Random();
            do
            {
                flag = 0;
                id = random.Next(100, 999999);
                foreach(Complaint c in list)
                {
                    if(c.ComplainID == id)
                    {
                        flag++;
                        break;
                    }
                }



            } while (flag == 1);
            return id;
        }


        static public int GetNumberISchecked(string resUser,bool ISCHECK)
        {
            List<Complaint> list = JsonConvert.DeserializeObject<List<Complaint>>(File.ReadAllText(MainWindow.Get_Dir_ALL_COMPLAINTS_json()));
            int n = 0;
            foreach (Complaint c in list)
            {
                if (c.RestaurantUserName == resUser && c.IsChecked == ISCHECK) { n++; }
            }
            return n;
        }
    }
}
