
namespace RestaurantManagementSystem.Models
{
    public class OrderItem
    {
        public int MenuItemId { get; set; }
        public string ItemName { get; set; } = "";
        public string Category { get; set; } = "";
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public decimal LineTotal
        {
            get { return UnitPrice * Quantity; }
        }
    }
}
