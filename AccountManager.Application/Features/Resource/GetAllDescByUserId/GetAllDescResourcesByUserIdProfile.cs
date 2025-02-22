using AutoMapper;

namespace AccountManager.Application.Features.Resource.GetAllDescByUserId
{
    public class GetAllDescResourcesByUserIdProfile : Profile
    {
        public GetAllDescResourcesByUserIdProfile()
        {
            CreateMap<Domain.Entities.Resource, GetAllDescResourcesByUserIdResponse>();
        }
    }
}