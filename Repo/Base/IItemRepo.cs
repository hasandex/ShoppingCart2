using ShoppingCart.Models;

namespace ShoppingCart.Repo.Base
{
    public interface IItemRepo
    {
        Task<IEnumerable<Item>> GetAll();
        Item? GetById(int id);
        int Create(CreateItemViewModel viewModel);
        int Update(UpdateItemViewModel viewModel);
    }
}
