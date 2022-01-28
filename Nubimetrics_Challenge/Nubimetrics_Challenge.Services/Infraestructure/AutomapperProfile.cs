using AutoMapper;
using Nubimetrics_Challenge.Services.User.Dtos;

namespace Nubimetrics_Challenge.Services.Infraestructure
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Core.Entities.User, UserDto>();
            CreateMap<UserDto, Core.Entities.User>()
                .ForMember(src => src.Id, dest => dest.Ignore());
        }
    }
}
