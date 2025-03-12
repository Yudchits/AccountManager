using AutoMapper;

namespace AccountManager.Application.Features.UserAccountBookmark.GetByUserId
{
    public class GetBookmarkedAccountsByUserIdProfile : Profile
    {
        public GetBookmarkedAccountsByUserIdProfile()
        {
            CreateMap<Domain.Entities.UserAccountBookmark, GetBookmarkedAccountsByUserIdResponse>()
                .ForMember
                (
                    dest => dest.Name, opt => opt.MapFrom(src => src.Account.Name)
                )
                .ForMember
                (
                    dest => dest.Login, opt => opt.MapFrom(src => src.Account.Login)
                )
                .ForMember
                (
                    dest => dest.Password, opt => opt.MapFrom(src => src.Account.Password)
                );
        }
    }
}