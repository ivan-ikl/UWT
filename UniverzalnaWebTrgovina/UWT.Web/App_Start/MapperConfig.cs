using System.Collections.Generic;
using AutoMapper;
using UWT.Models;
using UWT.Web.Extensions;
using UWT.Web.Models;

namespace UWT.Web 
{
    public static class MapperConfig
    {
        public static void RegisterMappings()
        {
            MapViewModelsToModels();
            MapModelsToViewModels(); 
        }

        static void MapViewModelsToModels()
        {
            // Helpers
            Mapper.CreateMap<UserViewModel, User>().ConvertUsing(user => null);
            Mapper.CreateMap<int, List<Product>>().ConvertUsing(list => null);
            Mapper.CreateMap<int, List<PageStyle>>().ConvertUsing(list => null);
            Mapper.CreateMap<int, List<Shop>>().ConvertUsing(list => null);
            Mapper.CreateMap<string, Image>().ConvertUsing(img => null);

            // Models

            Mapper.CreateMap<RegisterViewModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            Mapper.CreateMap<IndexViewModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            Mapper.CreateMap<CategoryViewModel, Category>();

            Mapper.CreateMap<PageLayoutViewModel, PageLayout>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }

        static void MapModelsToViewModels()
        {
            // Helpers
            Mapper.CreateMap<List<Product>, int>().ConvertUsing(list => list.Count);
            Mapper.CreateMap<List<PageStyle>, int>().ConvertUsing(list => list.Count);
            Mapper.CreateMap<List<Shop>, int>().ConvertUsing(list => list.Count);
            Mapper.CreateMap<Image, string>().ConvertUsing(img => img.Source());

            // Models

            Mapper.CreateMap<User, IndexViewModel>()
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.ProfileImage()));

            Mapper.CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.ProfileImage()))
                .ForMember(dest => dest.Blocked, opt => opt.MapFrom(src => src.IsBlocked()));

            Mapper.CreateMap<PageLayout, PageLayoutViewModel>();
            Mapper.CreateMap<Category, CategoryViewModel>();
        }
    }
}