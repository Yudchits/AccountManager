using AccountManager.Application.Features.Account.Create;
using AutoMapper;
using System.Linq;

namespace AccountManager.Application.Features.Account.GetByResourceId
{
    public class GetAccountsByResourceIdProfile : Profile
    {
        public GetAccountsByResourceIdProfile()
        {
            CreateMap<Domain.Entities.Account, GetAccountsByResourceIdResponse>()
                .ForMember
                (
                    dest => dest.IsBookmarked,
                    opt => opt.MapFrom(src => !src.Bookmarks.Any())
                );
            CreateMap<GetAccountsByResourceIdResponse, CreateAccountRequest>();
        }
    }
}