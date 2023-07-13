using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace WebWallet.Services.Identity.Interfaces
{
    public interface IIdentityService
    {
        Task<IdentityUser> GetCurrentUserAsync(ClaimsPrincipal user);
    }
}
