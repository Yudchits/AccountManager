using AutoMapper;

namespace AccountManager.Application.Features.Resource.GetAll
{
    public class GetAllResourceProfile : Profile
    {
        public GetAllResourceProfile()
        {
            CreateMap<Domain.Entities.Resource, GetAllResourceResponse>();
        }
    }
}