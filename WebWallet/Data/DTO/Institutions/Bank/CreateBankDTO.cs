using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebWallet.Data.DTO.Institutions.Bank
{
    public class CreateBankDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
