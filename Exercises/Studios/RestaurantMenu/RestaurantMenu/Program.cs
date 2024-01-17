

using RestaurantMenu;

//List<MenuItem> menuList = new List<MenuItem>();

MenuItem tacos = new(1.99, "Tacos", "Main");
MenuItem burgers = new(5.99, "Burger", "Main");
MenuItem fishSauce = new(1.99, "Fish Sauce", "App");

//menuList.Add(tacos);
//menuList.Add(burgers);
//menuList.Add(fishSauce);

//foreach (MenuItem item in menuList)
//{
//    Console.WriteLine(item.Price.ToString() + " " + item.Description.ToString() + " " + item.Category.ToString() + " " + item.Created.ToString());
//}

Menu menu = new Menu();
menu.AddMenuItem(tacos);
menu.AddMenuItem(burgers);
menu.AddMenuItem(fishSauce);

foreach (MenuItem item in menu.MenuItems)
{
    Console.WriteLine(item.Price.ToString() + " " + item.Description.ToString() + " " + item.Category.ToString() + " " + item.Created.ToString());
}