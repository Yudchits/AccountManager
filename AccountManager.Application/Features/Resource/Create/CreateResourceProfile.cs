using AutoMapper;

namespace AccountManager.Application.Features.Resource.Create
{
    public class CreateResourceProfile : Profile
    {
        public CreateResourceProfile()
        {
            CreateMap<CreateResourceRequest, Domain.Entities.Resource>();
            CreateMap<Domain.Entities.Resource, CreateResourceResponse>();
        }
    }
}