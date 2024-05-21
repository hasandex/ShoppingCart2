using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Item>? Items { get; set; } = new List<Item>();
    }
}
