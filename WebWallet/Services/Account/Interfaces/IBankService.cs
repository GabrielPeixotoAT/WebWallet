using System.Security.Claims;
using WebWallet.Data.DTO.Account.Bank;

namespace WebWallet.Services.Account.Interfaces
{
    public interface IBankService
    {
        Task<CreateBankDTO> CreateWithUserAsync(CreateBankDTO bank, ClaimsPrincipal user);
        Task<ReadBankDTO> ReadByIdAsync(int id);
        Task<IEnumerable<ReadBankDTO>> ReadAllByUserAsync(ClaimsPrincipal principal);
        Task<IEnumerable<ReadBankDTO>> ReadAllBylUserWithAccountsAsync(ClaimsPrincipal principal);
        Task<UpdateBankDTO> Update(UpdateBankDTO updateBank);
        Task DeleteAsync(int id);
    }
}
