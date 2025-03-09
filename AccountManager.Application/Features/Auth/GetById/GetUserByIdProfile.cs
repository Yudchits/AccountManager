using AccountManager.Domain.Entities;
using AutoMapper;

namespace AccountManager.Application.Features.Auth.GetById
{
    public class GetUserByIdProfile : Profile
    {
        public GetUserByIdProfile()
        {
            CreateMap<User, GetUserByIdResponse>();
        }
    }
}