using AutoMapper;
using WebWallet.Data.DTO.Account.Bank;
using WebWallet.Models.Account;

namespace WebWallet.Profiles.Account
{
    public class BankProfile : Profile
    {
        public BankProfile() 
        {
            CreateMap<CreateBankDTO, Bank>();
            CreateMap<UpdateBankDTO, Bank>();
            CreateMap<Bank, ReadBankDTO>();
        }
    }
}
