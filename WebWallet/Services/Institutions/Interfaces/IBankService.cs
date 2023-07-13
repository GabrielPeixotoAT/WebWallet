using System.Security.Claims;
using WebWallet.Data.DTO.Institutions.Bank;

namespace WebWallet.Services.Institutions.Interfaces
{
    public interface IBankService
    {
        Task<CreateBankDTO> CreateAsyncWithUser(CreateBankDTO bank, ClaimsPrincipal user);
        Task<ReadBankDTO> ReadByIdAsync(int id);
        Task<IEnumerable<ReadBankDTO>> ReadAllByUserAsync(ClaimsPrincipal principal);
        Task<UpdateBankDTO> Update(UpdateBankDTO updateBank);
        Task DeleteAsync(int id);
    }
}
