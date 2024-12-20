using AccountManager.Domain.Entities;
using AutoMapper;

namespace AccountManager.Application.Features.Update
{
    public class UpdateAccountProfile : Profile
    {
        public UpdateAccountProfile()
        {
            CreateMap<UpdateAccountRequest, Account>();
            CreateMap<Account, UpdateAccountResponse>();
        }
    }
}