using AutoMapper;

namespace AccountManager.Application.Features.Account.GetAll
{
    public class GetAllAccountProfile : Profile
    {
        public GetAllAccountProfile()
        {
            CreateMap<Domain.Entities.Account, GetAllAccountResponse>();
        }
    }
}