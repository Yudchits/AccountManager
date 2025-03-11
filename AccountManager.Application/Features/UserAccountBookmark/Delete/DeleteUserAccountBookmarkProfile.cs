using AutoMapper;

namespace AccountManager.Application.Features.UserAccountBookmark.Delete
{
    public class DeleteUserAccountBookmarkProfile : Profile
    {
        public DeleteUserAccountBookmarkProfile()
        {
            CreateMap<DeleteUserAccountBookmarkRequest, Domain.Entities.UserAccountBookmark>();
        }
    }
}