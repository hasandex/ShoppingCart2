using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double TotalPrice { get; set; } = 0;
        public int Quantity { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
    }
}
