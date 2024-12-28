using AutoMapper;

namespace AccountManager.Application.Features.Account.GetById
{
    public class GetAccountByIdProfile : Profile
    {
        public GetAccountByIdProfile()
        {
            CreateMap<Domain.Entities.Account, GetAccountByIdResponse>();
        }
    }
}