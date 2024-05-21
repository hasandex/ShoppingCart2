using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingCart.Repo.Base
{
    public interface ICategoryRepo
    {
        IEnumerable<SelectListItem> GetCategoriesSelectList();
    }
}
