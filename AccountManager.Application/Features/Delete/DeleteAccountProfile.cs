using AccountManager.Domain.Entities;
using AutoMapper;

namespace AccountManager.Application.Features.Delete
{
    public class DeleteAccountProfile : Profile
    {
        public DeleteAccountProfile()
        {
            CreateMap<DeleteAccountRequest, Account>();
            CreateMap<Account, DeleteAccountResponse>();
        }
    }
}