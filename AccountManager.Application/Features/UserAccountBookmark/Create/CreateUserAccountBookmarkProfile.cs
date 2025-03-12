using AutoMapper;

namespace AccountManager.Application.Features.UserAccountBookmark.Create
{
    public class CreateUserAccountBookmarkProfile : Profile
    {
        public CreateUserAccountBookmarkProfile()
        {
            CreateMap<CreateUserAccountBookmarkRequest, Domain.Entities.UserAccountBookmark>();
        }
    }
}