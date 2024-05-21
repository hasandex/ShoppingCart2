using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public Item? Item { get; set; }
        public Cart? Cart { get; set; }
        public int Quantity { get; set; } // quantity of the selected item
        public double Price { get; set; } //quantity multiple the item price
    }
}
