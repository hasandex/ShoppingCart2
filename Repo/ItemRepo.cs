using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data;
using ShoppingCart.Models;
using ShoppingCart.Repo.Base;
using ShoppingCart.Services.@base;
using System.IO;

namespace ShoppingCart.Repo
{
    public class ItemRepo : IItemRepo
    {
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _appDbContext;
        public ItemRepo(AppDbContext appDbContext, IWebHostEnvironment env,IImageService imageService)
        {
            _appDbContext = appDbContext;
            _env = env;
            _imageService = imageService;
        }
        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _appDbContext.Items.Include(i => i.Category).AsNoTracking().ToListAsync();
        }
        public Item? GetById(int id)
        {
            var item =  _appDbContext.Items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                return item;
            }
            return null;
        }
        public int Create(CreateItemViewModel viewModel)
        {
            var item = new Item()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                CategoryId = viewModel.CategoryId,
                Price = viewModel.Price,
                Cover = _imageService.StoreImage(viewModel.FormFile,Settings.ItemImageStorePath),
            };
            _appDbContext.Items.Add(item);
            return _appDbContext.SaveChanges();
        }

        public int Update(UpdateItemViewModel viewModel)
        {
            var item = _appDbContext.Items.FirstOrDefault(i => i.Id == viewModel.Id);
            if (item != null)
            {
                if(viewModel.FormFile != null)
                {
                    var oldImagePath = Path.Combine($"{_env.WebRootPath}{Settings.ItemImageStorePath}",item.Cover);
                    File.Delete(oldImagePath);
                    item.Cover = _imageService.StoreImage(viewModel.FormFile,Settings.ItemImageStorePath);
                }
                item.Name = viewModel.Name;
                item.Description = viewModel.Description;
                item.CategoryId = viewModel.CategoryId;
                item.Price = viewModel.Price;
                _appDbContext.Update(item);
                return _appDbContext.SaveChanges();
            }
            return 0;
        }

        
    }
}
