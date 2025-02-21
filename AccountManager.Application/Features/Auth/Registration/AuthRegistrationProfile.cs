using AccountManager.Domain.Entities;
using AutoMapper;

namespace AccountManager.Application.Features.Auth.Registration
{
    public class AuthRegistrationProfile : Profile
    {
        public AuthRegistrationProfile()
        {
            CreateMap<AuthRegistrationRequest, User>();
        }
    }
}