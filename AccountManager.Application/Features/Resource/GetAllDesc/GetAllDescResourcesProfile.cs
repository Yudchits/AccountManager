using AutoMapper;

namespace AccountManager.Application.Features.Resource.GetAllDesc
{
    public class GetAllDescResourcesProfile : Profile
    {
        public GetAllDescResourcesProfile()
        {
            CreateMap<Domain.Entities.Resource, GetAllDescResourcesResponse>();
        }
    }
}