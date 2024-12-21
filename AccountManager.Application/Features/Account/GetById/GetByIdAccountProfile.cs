using AutoMapper;

namespace AccountManager.Application.Features.Account.GetById
{
    public class GetByIdAccountProfile : Profile
    {
        public GetByIdAccountProfile()
        {
            CreateMap<Domain.Entities.Account, GetByIdAccountResponse>();
        }
    }
}