using System.Collections.Generic;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Services
{
    public class AppData
    {
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }

    public class DataStore
    {
        public AppData Data { get; set; } = new AppData();

        public Customer? FindCustomerById(int id)
        {
            foreach (Customer customer in Data.Customers)
            {
                if (customer.CustomerId == id)
                {
                    return customer;
                }
            }

            return null;
        }

        public MenuItem? FindMenuItemById(int id)
        {
            foreach (MenuItem item in Data.MenuItems)
            {
                if (item.ItemId == id)
                {
                    return item;
                }
            }

            return null;
        }

        public Order? FindOrderById(int id)
        {
            foreach (Order order in Data.Orders)
            {
                if (order.OrderId == id)
                {
                    return order;
                }
            }

            return null;
        }
    }
}