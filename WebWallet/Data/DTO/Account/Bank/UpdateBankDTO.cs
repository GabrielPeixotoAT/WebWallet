using System.ComponentModel.DataAnnotations;

namespace WebWallet.Data.DTO.Account.Bank
{
    public class UpdateBankDTO
    {
        [Required]
        public int BankId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
