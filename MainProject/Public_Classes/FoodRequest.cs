using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Public_Classes
{
    internal class FoodRequest
    {
        public RequestType RequestType;
        public int RequestID {  get; set; }
        public Restaurant Restaurant { get; set; }
        public User User { get; set; }

        public FoodRequest(RequestType RequestType,Restaurant Restaurant, User user,int RequestID)
        {
            this.RequestType = RequestType;
            this.RequestID = RequestID;
            this.Restaurant = Restaurant;
            this.User = user;

        }
    }
}
