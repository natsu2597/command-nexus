using AutoMapper;
using CommandNexus.Platform.Service.Dtos;
using CommandNexus.Platform.Service.Models;

namespace CommandNexus.Platform.Service.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<PlatformModel, PlatformReadDto>();
            CreateMap<PlatformCreatedDto, PlatformModel>();
        }
    }
}
