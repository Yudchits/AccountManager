using AutoMapper;

namespace AccountManager.Application.Features.Account.GetAll
{
    public class GetAllAccountsProfile : Profile
    {
        public GetAllAccountsProfile()
        {
            CreateMap<Domain.Entities.Account, GetAllAccountsResponse>();
        }
    }
}