using Microsoft.AspNetCore.Hosting;
using ShoppingCart.Services.@base;

namespace ShoppingCart.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _environment;
        public ImageService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public string StoreImage(IFormFile formFile,string path)
        {
            var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(formFile.FileName)}";
            var fullPath = Path.Combine($"{_environment.WebRootPath}{path}", fileName);
            using var stream = File.Create(fullPath);
            formFile.CopyToAsync(stream);
            return fileName;
        }
    }
}
