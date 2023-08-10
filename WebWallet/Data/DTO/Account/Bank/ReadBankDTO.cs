using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebWallet.Data.DTO.Account.Account;

namespace WebWallet.Data.DTO.Account.Bank
{
    public class ReadBankDTO
    {
        [Required]
        public int BankId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public List<ReadAccountDTO> Accounts { get; set; }
    }
}
