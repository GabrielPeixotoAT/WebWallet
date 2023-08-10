using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebWallet.Data;
using WebWallet.Data.DTO.Account.Account;
using WebWallet.Models.Account;
using WebWallet.Services.Account.Interfaces;
using WebWallet.Services.Identity.Interfaces;

namespace WebWallet.Services.Account
{
    public class AccountService : IAccountService
    {
        private ApplicationDbContext context;
        private IMapper mapper;

        private IIdentityService identityService;
        private IBankService bankService;

        public AccountService(
            ApplicationDbContext context, 
            IMapper mapper, 
            IIdentityService identityService, 
            IBankService bankService)
        {
            this.context = context;
            this.mapper = mapper;
            this.identityService = identityService;
            this.bankService = bankService;
        }

        public async Task<CreateAccountDTO> CreateWithUserAsync(CreateAccountDTO createAccount, ClaimsPrincipal user)
        {
            if (!await AvaliableToCreateWithUserAsync(createAccount, user))
                throw new ApplicationException("Error to create account");

            Models.Account.Account account = mapper.Map<Models.Account.Account>(createAccount);

            await context.Accounts.AddAsync(account);
            await context.SaveChangesAsync();

            return createAccount;
        }

        private async Task<bool> AvaliableToCreateWithUserAsync(CreateAccountDTO createAccount, ClaimsPrincipal user)
        {
            var bank = await bankService.ReadByIdAsync(createAccount.BankId);

            var iUser = await identityService.GetCurrentUserAsync(user);

            return (bank.UserId == iUser.Id);
        }
        
        private async Task<CreateAccountDTO> CreateAsync(CreateAccountDTO createAccount)
        {
            Models.Account.Account account = mapper.Map<Models.Account.Account>(createAccount);

            await context.Accounts.AddAsync(account);
            await context.SaveChangesAsync();

            return createAccount;
        }

        public async Task<ReadAccountDTO> ReadById(int id)
        {
            Models.Account.Account? account = await context.Accounts.FindAsync(id);

            if (account == null)
                throw new ApplicationException("Not found");

            return mapper.Map<ReadAccountDTO>(account);
        }

        public async Task<IEnumerable<ReadAccountDTO>> ReadByBank(int bankId)
        {
            List<Models.Account.Account> accounts = 
                await context.Accounts.Where(ac => ac.BankId == bankId).ToListAsync();

            return mapper.Map<IEnumerable<ReadAccountDTO>>(accounts);
        }

        public async Task<IEnumerable<ReadAccountDTO>> ReadByUser(ClaimsPrincipal princial)
        {
            IdentityUser user = await identityService.GetCurrentUserAsync(princial);

            List<Models.Account.Account> accounts =
                await context.Accounts.Where(ac => ac.Bank.User == user).ToListAsync();

            return mapper.Map<IEnumerable<ReadAccountDTO>>(accounts);
        }

        public async Task<UpdateAccountDTO> UpdateAsync(UpdateAccountDTO update)
        {
            var account = await GetById(update.AccountId);

            var bank = await bankService.ReadByIdAsync(update.BankId);

            account.AccountType = update.AccountType;
            account.Number = update.Number;
            account.Bank = mapper.Map<Bank>(bank);
            account.ColorCode = update.ColorCode;

            await context.SaveChangesAsync();

            return update;
        }

        private async Task<Models.Account.Account> GetById(int id)
        {
            var account = await context.Accounts.FindAsync(id);

            if (account == null)
                throw new ApplicationException("Account not found");

            return account;
        }

        public async Task DeleteAsync(int id)
        {
            context.Remove(GetById(id));
            await context.SaveChangesAsync();
        }
    }
}
