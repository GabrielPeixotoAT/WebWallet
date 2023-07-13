using WebWallet.Services.Identity;
using WebWallet.Services.Identity.Interfaces;
using WebWallet.Services.Institutions;
using WebWallet.Services.Institutions.Interfaces;

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
