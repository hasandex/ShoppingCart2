using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCart.CustomDataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.ViewModel
{
    public class UpdateItemViewModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public double Price { get; set; } = 0;
        [MaxFileSize(Settings.MaxImgSize)]
        [AllowedExtension(Settings.AllowedImgExtensions)]
        public IFormFile? FormFile { get; set; }
        public string? Cover { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> CategoriesSelectList { get; set; } = new List<SelectListItem>();

    }
}
