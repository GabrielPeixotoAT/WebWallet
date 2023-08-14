using WebWallet.Data.DTO.Account.Account;
using WebWallet.Data.DTO.Account.Bank;
using WebWallet.Models.Account;

namespace WebWallet.Data.ViewModel.Accounts
{
    public class AccountViewModel
    {
        public IEnumerable<ReadBankDTO> banks;
        public AccountType AccountTypes;
        public CreateBankDTO createBank;
        public CreateAccountDTO createAccount;
    }
}
