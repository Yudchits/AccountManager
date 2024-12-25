using AutoMapper;

namespace AccountManager.Application.Features.Resource.GetAll
{
    public class GetAllResourcesProfile : Profile
    {
        public GetAllResourcesProfile()
        {
            CreateMap<Domain.Entities.Resource, GetAllResourcesResponse>();
        }
    }
}