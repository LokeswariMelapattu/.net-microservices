namespace PlatformService.Profiles
{
    using AutoMapper;
    using PlatformService.Dtos;
    using PlatformService.Models;

    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<Platform, PlatformReadDTO>();
            CreateMap<PlatformCreateDTO, Platform>();
            CreateMap<Platform, PlatformCreateDTO>();
        }
    }
}