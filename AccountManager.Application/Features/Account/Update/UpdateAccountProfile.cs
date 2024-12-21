using AutoMapper;

namespace AccountManager.Application.Features.Account.Update
{
    public class UpdateAccountProfile : Profile
    {
        public UpdateAccountProfile()
        {
            CreateMap<UpdateAccountRequest, Domain.Entities.Account>();
            CreateMap<Domain.Entities.Account, UpdateAccountResponse>();
        }
    }
}