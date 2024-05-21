using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public double Total
        {
            get { return CartItems.Sum(ci => ci.Quantity * ci.Price); } //sum of the total price for each item in the shopping cart
        }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public ICollection<CartItem>? CartItems { get; set; }
    }
}
