using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WebWallet.Data.DTO.Account.Bank;
using WebWallet.Data;
using WebWallet.Models.Account;
using WebWallet.Services.Identity.Interfaces;
using WebWallet.Services.Account.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebWallet.Services.Account
{
    public class BankService : IBankService
    {
        private ApplicationDbContext context;
        IMapper mapper;

        private IIdentityService identityService;

        public BankService(ApplicationDbContext context, IMapper mapper, IIdentityService identityService)
        {
            this.context = context;
            this.mapper = mapper;
            this.identityService = identityService;
        }

        public async Task<CreateBankDTO> CreateWithUserAsync(CreateBankDTO createBank, ClaimsPrincipal user)
        {
            createBank.User = await identityService.GetCurrentUserAsync(user);

            createBank = await CreateAsync(createBank);

            return createBank;
        }

        private async Task<CreateBankDTO> CreateAsync(CreateBankDTO createBank)
        {
            Bank bank = mapper.Map<Bank>(createBank);

            await context.Banks.AddAsync(bank);
            await context.SaveChangesAsync();

            return createBank;
        }

        public async Task<ReadBankDTO> ReadByIdAsync(int id)
        {
            Bank bank = await GetByIdAsync(id);

            return mapper.Map<ReadBankDTO>(bank);
        }

        public async Task<IEnumerable<ReadBankDTO>> ReadAllByUserAsync(ClaimsPrincipal principal)
        {
            IdentityUser user = await identityService.GetCurrentUserAsync(principal);

            List<Bank> banks = context.Banks.Where(b => b.User == user).ToList();

            return mapper.Map<List<ReadBankDTO>>(banks);
        }

        public async Task<IEnumerable<ReadBankDTO>> ReadAllBylUserWithAccountsAsync(ClaimsPrincipal principal)
        {
            IdentityUser user = await identityService.GetCurrentUserAsync(principal);

            List<Bank> banks = context.Banks.Include(bank => bank.Accounts).Where(b => b.User == user).ToList();

            return mapper.Map<List<ReadBankDTO>>(banks);
        }

        public async Task<UpdateBankDTO> Update(UpdateBankDTO updateBank)
        {
            Bank bank = await GetByIdAsync(updateBank.BankId);

            bank.Name = updateBank.Name;

            await context.SaveChangesAsync();

            return updateBank;
        }

        public async Task DeleteAsync(int id)
        {
            Bank bank = await GetByIdAsync(id);

            context.Banks.Remove(bank);
            await context.SaveChangesAsync();
        }

        private async Task<Bank> GetByIdAsync(int id)
        {
            Bank? bank = await context.Banks.FindAsync(id);

            if (bank == null)
                throw new ApplicationException("Bank not found");

            return bank;
        }
    }
}
