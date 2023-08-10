using System.ComponentModel.DataAnnotations;
using WebWallet.Data.DTO.Account.Bank;
using WebWallet.Models.Account;

namespace WebWallet.Data.DTO.Account.Account
{
    public class UpdateAccountDTO
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Number { get; set; }
        [Required]
        public AccountType AccountType { get; set; }
        [Required]
        public decimal OpeningBalance { get; set; }
        [Required]
        public decimal CurrentBalance { get; set; }
        [Required]
        public int BankId { get; set; }
        public ReadBankDTO Bank { get; set; }
        [Required]
        [StringLength(7)]
        public string ColorCode { get; set; }
    }
}
