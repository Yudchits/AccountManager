using AutoMapper;

namespace AccountManager.Application.Features.Account.GetByResourceId
{
    public class GetAccountsByResourceIdProfile : Profile
    {
        public GetAccountsByResourceIdProfile()
        {
            CreateMap<Domain.Entities.Account, GetAccountsByResourceIdResponse>();
        }
    }
}