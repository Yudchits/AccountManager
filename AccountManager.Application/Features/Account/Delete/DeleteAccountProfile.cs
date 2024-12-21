using AutoMapper;

namespace AccountManager.Application.Features.Account.Delete
{
    public class DeleteAccountProfile : Profile
    {
        public DeleteAccountProfile()
        {
            CreateMap<DeleteAccountRequest, Domain.Entities.Account>();
            CreateMap<Domain.Entities.Account, DeleteAccountResponse>();
        }
    }
}