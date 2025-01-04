using AutoMapper;

namespace AccountManager.Application.Features.Resource.GetAllShort
{
    public class GetAllShortResourcesProfile : Profile
    {
        public GetAllShortResourcesProfile()
        {
            CreateMap<Domain.Entities.Resource, GetAllShortResourcesResponse>();
        }
    }
}