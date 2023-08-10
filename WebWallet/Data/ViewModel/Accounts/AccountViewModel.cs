﻿using WebWallet.Data.DTO.Account.Account;
using WebWallet.Data.DTO.Account.Bank;

namespace WebWallet.Data.ViewModel.Accounts
{
    public class AccountViewModel
    {
        public IEnumerable<ReadBankDTO> banks;
        public CreateBankDTO createBank;
        public CreateAccountDTO createAccount;
    }
}
