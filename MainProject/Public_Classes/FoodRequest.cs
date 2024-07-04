using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Public_Classes
{
    public class FoodRequest
    {
        public RequestType RequestType;
        public int RequestID {  get; set; }
        public string RestaurantUserName { get; set; }
        public string User_UserName { get; set; }
        public int FoodID { get; set; }

        public FoodRequest() { }
        public FoodRequest(RequestType RequestType,string RestaurantUserName, string User_UserName,int RequestID)
        {
            this.RequestType = RequestType;
            this.RequestID = RequestID;
            this.RestaurantUserName = RestaurantUserName;
            this.User_UserName = User_UserName;

        }
    }
}
