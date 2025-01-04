using AutoMapper;

namespace AccountManager.Application.Features.Resource.GetAllFull
{
    public class GetAllFullResourcesProfile : Profile
    {
        public GetAllFullResourcesProfile()
        {
            CreateMap<Domain.Entities.Resource, GetAllFullResourcesResponse>();
        }
    }
}