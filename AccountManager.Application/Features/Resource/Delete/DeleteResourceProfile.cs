using AutoMapper;

namespace AccountManager.Application.Features.Resource.Delete
{
    public class DeleteResourceProfile : Profile
    {
        public DeleteResourceProfile()
        {
            CreateMap<DeleteResourceRequest, Domain.Entities.Resource>();
        }
    }
}