using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Repo.Base;
using ShoppingCart.Services.@base;

namespace ShoppingCart.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepo _cartRepo;
        private readonly IUserService _userService;
        private readonly string _userId;
        public CartController(ICartRepo cartRepo,IUserService userService)
        {
            _cartRepo = cartRepo;
            _userService = userService;
            _userId = _userService.GetUserId();
            if (string.IsNullOrEmpty(_userId))
            {
                throw new UnauthorizedAccessException("You must be logged in to perform this action");
            }
        }
        public async Task<IActionResult> Index()
        {
            var carts = _cartRepo.GetCartByUserId(_userId);
            return View(carts);
        }
        public IActionResult Add(int itemId, int quantity)
        { 
            _cartRepo.AddItem(itemId, quantity);
            TempData["CartSucssess"] = "the item has been added to yout cart successfully";
            return RedirectToAction(controllerName:"Item",actionName:"Index");
        }
    }
}
