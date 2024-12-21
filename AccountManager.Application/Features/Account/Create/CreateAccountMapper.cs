using AccountManager.Domain.Entities;
using AutoMapper;

namespace AccountManager.Application.Features.Account.Create
{
    public class CreateAccountMapper : Profile
    {
        public CreateAccountMapper()
        {
            CreateMap<CreateAccountRequest, Domain.Entities.Account>();
            CreateMap<Domain.Entities.Account, CreateAccountResponse>();
        }
    }
}