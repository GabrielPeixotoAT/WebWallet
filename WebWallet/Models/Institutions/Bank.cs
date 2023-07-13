using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebWallet.Models.Institutions
{
    public class Bank
    {
        [Key]
        [Required]
        public int BankId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
