

using RestaurantMenu;

List<MenuItem> menuList = new List<MenuItem>();

MenuItem tacos = new(1.99, "Tacos", "Main");
MenuItem burgers = new(5.99, "Burger", "Main");
MenuItem fishSauce = new(1.99, "Fish Sauce", "App");

menuList.Add(tacos);
menuList.Add(burgers);
menuList.Add(fishSauce);

foreach (MenuItem item in menuList)
{
    Console.WriteLine(item.Price.ToString() + " " + item.Description.ToString() + " " + item.Category.ToString() + " " + item.Created.ToString());
}