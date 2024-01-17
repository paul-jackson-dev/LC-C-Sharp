using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu
{
    public class Menu
    {
        public List<MenuItem> MenuItems { get; }

        public Menu()
        {
            this.MenuItems = new();
        }

        public void AddMenuItem(MenuItem item)
        {
            this.MenuItems.Add(item);
        }

    }
}



