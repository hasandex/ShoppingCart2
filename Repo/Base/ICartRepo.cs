namespace ShoppingCart.Repo.Base
{
    public interface ICartRepo
    {
        Cart CreateCart(string userId);
        Cart GetCartByUserId(string userId);
        int AddItem(int itemId, int quantity);
        double TotalPrice(string userId);
    }
}
