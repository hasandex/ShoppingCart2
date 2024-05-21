using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCart.Data;
using ShoppingCart.Repo.Base;

namespace ShoppingCart.Repo
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<SelectListItem> GetCategoriesSelectList()
        {
            return _appDbContext.Categories.Select(c=> new SelectListItem { Value = c.Id.ToString(), Text=c.Name});
        }
    }
}
