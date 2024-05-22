namespace ShoppingCart.Repo.Base
{
    public interface ICartRepo
    {
        Cart CreateCart(string userId);
        Cart GetCartByUserId(string userId);
        CartItem GetCartItem(int itemId);
        int AddItem(int itemId, int quantity);
        int RemoveItem(int itemId);
        double TotalPrice(string userId);
        int Count(string userId);
    }
}
