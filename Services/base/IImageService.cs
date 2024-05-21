namespace ShoppingCart.Services.@base
{
    public interface IImageService
    {
        string StoreImage(IFormFile formFile, string path);
    }
}
