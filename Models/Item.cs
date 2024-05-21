using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public string Cover { get; set; } = string.Empty;

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; } = 0;
        public Category? Category { get; set; } = default!;

        public ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<CartItem>? CartItems { get; set; }
    }
}
