using Microsoft.AspNetCore.Identity;
using ShoppingCart.Services.@base;

namespace ShoppingCart.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public string GetUserId()
        {
            return _userManager.GetUserId(_httpContextAccessor.HttpContext.User);        
        }
    }
}
