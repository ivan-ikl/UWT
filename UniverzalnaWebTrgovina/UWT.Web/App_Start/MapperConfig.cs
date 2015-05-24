using AutoMapper;
using UWT.Models;
using UWT.Web.Models;

namespace UWT.Web {

    public static class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<RegisterViewModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
        }
    }

}