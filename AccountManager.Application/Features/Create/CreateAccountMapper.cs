using AccountManager.Domain.Entities;
using AutoMapper;

namespace AccountManager.Application.Features.Create
{
    public class CreateAccountMapper : Profile
    {
        public CreateAccountMapper()
        {
            CreateMap<CreateAccountRequest, Account>();
            CreateMap<Account, CreateAccountResponse>();
        }
    }
}