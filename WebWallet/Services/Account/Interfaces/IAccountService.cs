using System.Security.Claims;
using WebWallet.Data.DTO.Account.Account;

namespace WebWallet.Services.Account.Interfaces
{
    public interface IAccountService
    {
        Task<CreateAccountDTO> CreateWithUserAsync(CreateAccountDTO createAccount, ClaimsPrincipal user);
        Task<ReadAccountDTO> ReadById(int id);
        Task<IEnumerable<ReadAccountDTO>> ReadByBank(int bankId);
        Task<IEnumerable<ReadAccountDTO>> ReadByUser(ClaimsPrincipal user);
        Task<UpdateAccountDTO> UpdateAsync(UpdateAccountDTO account);
        Task DeleteAsync(int id);
    }
}
