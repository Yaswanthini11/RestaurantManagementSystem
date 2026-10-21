
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantManagementSystem.Models
{
  
    public class Order
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Placed;
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public decimal GrandTotal
        {
            get { return Items.Sum(item => item.LineTotal); }
        }
    }
}
