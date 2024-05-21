using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class OrderItem
    {
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public Order? Order { get; set; } = default!;
        public Item? Item { get; set; } = default!;
    }
}
