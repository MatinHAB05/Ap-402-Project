using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        static public int GetRANDOM()
        {
            List<FoodRequest> foodRequest = JsonConvert.DeserializeObject<List<FoodRequest>>(File.ReadAllText(@"C:\Users\ASUS\3D Objects\Project-Ap\SecondLayout\MainProject\Ap-402-Project\MainProject\JsonFiles\FoodRequest\All_FoodRequest.json"));
            int flag  , rand;
            do
            {
                flag = 0;
                rand = (new Random()).Next(100, 999999);
                foreach (FoodRequest f in foodRequest)
                {
                    if (f.RequestID == rand)
                    {
                        flag = 1; break;
                    }
                }
            } while (flag == 1);
            return rand;
        }
    }
}
