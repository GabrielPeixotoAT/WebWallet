using AutoMapper;
using WebWallet.Data.DTO.Institutions.Bank;
using WebWallet.Models.Institutions;

namespace WebWallet.Profiles.Institutions
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
