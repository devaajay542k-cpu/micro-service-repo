using AutoMapper;
using platformService.Data;
using PlatformService.Models;

namespace platformService.Profiles
{
    public class PlatformProfile:Profile
    {
        public PlatformProfile()
        {
            //source-->destination
            CreateMap<Platform,PlatformReadDto>();
            CreateMap<PlatformWriteDto,Platform>();
        }
        
    }
    
}