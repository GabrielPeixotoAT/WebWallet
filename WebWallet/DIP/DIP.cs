using WebWallet.Services.Identity;
using WebWallet.Services.Identity.Interfaces;
using WebWallet.Services.Account;
using WebWallet.Services.Account.Interfaces;

namespace WebWallet.DIP
{
    public class DIP
    {
        public DIP(IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            
            services.AddTransient<IBankService, BankService>();
        }
    }
}
