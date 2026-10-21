using System;
using System.Text.Json.Nodes;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Services
{
    public class OrderService
    {
        private AppData data;
        private JsonDataService jsonService;

        public OrderService(AppData data, JsonDataService jsonService)
        {
            this.data = data;
            this.jsonService = jsonService;
        }

        public void CreateOrder()
        {
            Order order = new Order();

            Console.Write("Enter Order ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("Invalid Order ID.");
                return;
            }

        }
    }
}
     
