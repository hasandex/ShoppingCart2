using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data;
using ShoppingCart.Repo.Base;
using ShoppingCart.Services.@base;

namespace ShoppingCart.Repo
{
    public class CartRepo : ICartRepo
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUserService _userService;
        private readonly string _userId;
        public CartRepo(AppDbContext appDbContext,IUserService userService)
        {
            _appDbContext = appDbContext;
            _userService = userService;
            _userId = _userService.GetUserId();
            if (string.IsNullOrEmpty(_userId))
            {
                throw new UnauthorizedAccessException("You must be logged in to perform this action");
            }
        }
        public int AddItem(int itemId, int quantity)
        {  
            using (var transaction = _appDbContext.Database.BeginTransaction())
            {
                try
                {
                    var userCart = GetCartByUserId(_userId);
                    if (userCart == null)
                    {
                        userCart = CreateCart(_userId);
                    }
                    var cartItem = userCart?.CartItems?.FirstOrDefault(ci => ci.ItemId == itemId);
                    if (cartItem != null)
                    {
                        cartItem.Quantity += quantity;
                    }
                    else
                    {
                        var item = _appDbContext.Items.FirstOrDefault(i => i.Id == itemId);
                        if (item == null)
                        {
                            throw new ArgumentException($"Item with ID {itemId} not found");
                        }
                        cartItem = new CartItem
                        {
                           // ItemId = itemId,
                            Item = item,
                            Quantity = quantity,
                            CartId = userCart.Id,
                            Price = item.Price
                        };
                        _appDbContext.CartItems.Add(cartItem);
                    }
                    userCart.Total += cartItem.Quantity * cartItem.Price;
                    _appDbContext.SaveChanges();
                    transaction.Commit();
                    return cartItem.Quantity;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }             
        }

        public Cart CreateCart(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("You must be logged in to perform this action");
            }
            var newCart = new Cart()
            {
                UserId = userId,
            };
           _appDbContext.Carts.AddAsync(newCart);
           _appDbContext.SaveChanges();
           return newCart;
  
        }

        public Cart GetCartByUserId(string userId)
        {
            var cart = _appDbContext.Carts.Include(c=>c.CartItems)
                .ThenInclude(ci => ci.Item)
                .ThenInclude(i=>i.Category)
                .FirstOrDefault(c=>c.UserId == userId);
            if(cart == null)
            {
                return null;
            }
            return cart;
        }
        public double TotalPrice(string userId)
        {
            var cart = GetCartByUserId(userId);
            return cart.Total;
        }
    }
}
