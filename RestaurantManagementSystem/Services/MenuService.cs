
using System;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Services
{
    public class MenuService
    {
        private AppData data;

        private JsonDataService jsonService;

        public MenuService(AppData data, JsonDataService jsonService)
        {
            this.data = data;
            this.jsonService = jsonService;
        }

        public void AddMenuItem()
        {
            MenuItem item = new MenuItem();

            Console.Write("Enter Item ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("Invalid ID");
                return;
            }

            foreach (MenuItem m in data.MenuItems)
            {
                if (m.ItemId == id)
                {
                    Console.WriteLine("already exists");
                    return;
                }
            }

            item.ItemId = id;

            Console.Write("Enter name: ");
            item.Name = Console.ReadLine() ?? "";

            Console.Write("Enter category: ");
            item.Category = Console.ReadLine() ?? "";

            Console.Write("Enter price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            item.Price = price;
            item.IsAvailable = true;

            data.MenuItems.Add(item);
            jsonService.SaveData(data);

            Console.WriteLine("Item added successfully.");
        }

        public void DisplayMenu()
        {
            foreach (MenuItem item in data.MenuItems)
            {
                Console.WriteLine(item.ItemId +" "+item.Name + " " +
                    item.Category + " " + item.Price + " " + item.IsAvailable);
            }
        }

        public void SearchMenu()
        {
            Console.Write("Enter item name: ");
            string name = Console.ReadLine() ?? "";
            bool found = false;

            foreach (MenuItem item in data.MenuItems)
            {
                if (item.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(item.ItemId + " " + item.Name + " " + item.Price);
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("Item not found.");
        }

        public void UpdateMenuItem()
        {
            Console.Write("Enter Item ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            foreach (MenuItem item in data.MenuItems)
            {
                if (item.ItemId == id)
                {
                    Console.Write("Enter new name: ");
                    item.Name = Console.ReadLine() ?? "";

                    Console.Write("Enter new category: ");
                    item.Category = Console.ReadLine() ?? "";

                    Console.Write("Enter new price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
                    {
                        Console.WriteLine("Invalid price.");
                        return;
                    }

                    item.Price = price;
                    jsonService.SaveData(data);

                    Console.WriteLine("Item updated.");
                    return;
                }
            }

            Console.WriteLine("Item not found.");
        }

        public void ChangeAvailability()
        {
            Console.Write("Enter Item ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID");
                return;
            }

            foreach (MenuItem item in data.MenuItems)
            {
                if (item.ItemId == id)
                {
                    item.IsAvailable = !item.IsAvailable;
                    jsonService.SaveData(data);

                    Console.WriteLine("Availability changed");
                    return;
                }
            }

            Console.WriteLine("Item not foun");
        }

        public void DeleteMenuItem()
        {
            Console.Write("Enter Item ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID");
                return;
            }

            foreach (Order order in data.Orders)
            {
                foreach (OrderItem orderItem in order.Items)
                {
                    if (orderItem.MenuItemId == id)
                    {
                        Console.WriteLine("Item is used in order history");
                        return;
                    }
                }
            }

            foreach (MenuItem item in data.MenuItems)
            {
                if (item.ItemId == id)
                {
                    data.MenuItems.Remove(item);
                    jsonService.SaveData(data);

                    Console.WriteLine("Item deleted.");
                    return;
                }
            }

            Console.WriteLine("Item not found.");
        }
    }
}
