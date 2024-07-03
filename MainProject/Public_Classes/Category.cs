using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Public_Classes
{
    internal class Category
    {
        public string Name { get; set; }
        public List<FoodClass> Foods { get; set; }

        public Category(string name, List<FoodClass> foods)
        {
            Name = name;
            Foods = foods;
        }
    }
}
