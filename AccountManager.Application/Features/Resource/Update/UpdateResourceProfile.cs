using AutoMapper;

namespace AccountManager.Application.Features.Resource.Update
{
    public class UpdateResourceProfile : Profile
    {
        public UpdateResourceProfile()
        {
            CreateMap<UpdateResourceRequest, Domain.Entities.Resource>();
        }
    }
}