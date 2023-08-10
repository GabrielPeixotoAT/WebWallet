using System.ComponentModel.DataAnnotations;

namespace WebWallet.Models.Account
{
    public class Account
    {
        [Key]
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
        public Bank Bank { get; set; }
        [Required]
        [StringLength(7)]
        public string ColorCode { get; set; }
    }
}
