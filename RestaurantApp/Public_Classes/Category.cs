using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Public_Classes
{
    public class Category
    {
        public string Name { get; set; }
        public List<FoodClass> Foods { get; set; }
        public Category() { }   
        public Category(string name, List<FoodClass> foods)
        {
            Name = name;
            Foods = foods;
        }
        public Category cClone()
        {
            Category c = new Category();
            c.Foods = new List<FoodClass>();
            c.Name = Name;
            foreach (FoodClass food in Foods)
            {
                c.Foods.Add(food.cClone());

            }
            return c;
        }
    }
}
