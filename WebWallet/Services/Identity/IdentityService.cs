using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WebWallet.Services.Identity.Interfaces;

namespace WebWallet.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> userManager;

        public IdentityService(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityUser> GetCurrentUserAsync(ClaimsPrincipal user)
        {
            if (user.Identity == null)
                throw new ArgumentNullException(nameof(user.Identity));

            string userId = userManager.GetUserId(user);

            return await userManager.FindByIdAsync(userId);
        }
    }
}
