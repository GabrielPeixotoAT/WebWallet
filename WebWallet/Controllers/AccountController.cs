using Microsoft.AspNetCore.Mvc;
using WebWallet.Data.DTO.Account.Account;
using WebWallet.Data.DTO.Account.Bank;
using WebWallet.Data.ViewModel.Accounts;
using WebWallet.Services.Account.Interfaces;

namespace WebWallet.Controllers
{
    public class AccountController : Controller
    {
        IBankService bankService;
        IAccountService accountService;

        public AccountController(IBankService bankService, IAccountService accountService)
        {
            this.bankService = bankService;
            this.accountService = accountService;
        }

        public async Task<IActionResult> Index() 
        {
            AccountViewModel viewModel = new AccountViewModel();

            viewModel.banks = await bankService.ReadAllBylUserWithAccountsAsync(User);

            return View(viewModel);
        }

        public async Task<IActionResult> CreateAccount(CreateAccountDTO createAccount)
        {
            var result = await accountService.CreateWithUserAsync(createAccount, User);

            return Redirect("/Account");
        }

        public async Task<IActionResult> CreateBank(CreateBankDTO bank)
        {
            var result = await bankService.CreateWithUserAsync(bank, User);

            return Redirect("/Account");
        }

        public async Task<IActionResult> DeleteBank(int id)
        {
            await bankService.DeleteAsync(id);

            return Redirect("/Account");
        }

        public async Task<IActionResult> UpdateBankName([FromBody] UpdateBankDTO updateBank)
        {
            updateBank = await bankService.Update(updateBank);

            return Ok(updateBank.Name);
        }
    }
}
