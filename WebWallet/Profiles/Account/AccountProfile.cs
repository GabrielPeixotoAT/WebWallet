using AutoMapper;
using WebWallet.Data.DTO.Account.Account;

namespace WebWallet.Profiles.Account
{
    public class AccountProfile : Profile
    {
        public AccountProfile() 
        {
            CreateMap<CreateAccountDTO, Models.Account.Account>();
            CreateMap<Models.Account.Account, ReadAccountDTO>();
        }
    }
}
