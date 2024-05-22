using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public double Total { get; set; } = 0; //sum of the total price for each item in the shopping
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public int ItemsNumber { get; set; } = 0 ;
        public ICollection<CartItem> CartItems { get; set; }
    }
}
