using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu
{
    public class MenuItem
    {
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Created { get; set; }

        public MenuItem(double price, string description, string category)
        {
            Price = price;
            Description = description;
            Category = category;
            Created = DateTime.Now;
        }
    }
}
