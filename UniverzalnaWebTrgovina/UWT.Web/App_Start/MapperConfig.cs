using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
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
            Mapper.CreateMap<int, PageStyle>().ConvertUsing(style => null);
            Mapper.CreateMap<int, PageLayout>().ConvertUsing(layout => null);
            Mapper.CreateMap<string, Image>().ConvertUsing(img => null);

            // Models

            Mapper.CreateMap<RegisterViewModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            Mapper.CreateMap<IndexViewModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            Mapper.CreateMap<CategoryViewModel, Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            Mapper.CreateMap<PageLayoutViewModel, PageLayout>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            
            Mapper.CreateMap<PageStyleViewModel, PageStyle>();
            
            Mapper.CreateMap<ShopViewModel, Shop>()
                .ForMember(dest => dest.Owner, opt => opt.Ignore());

            Mapper.CreateMap<ProductViewModel, Product>()
                .ForMember(dest => dest.Shop, opt => opt.Ignore())
                .ForMember(dest => dest.Categories, opt => opt.Ignore());
        }

        static void MapModelsToViewModels()
        {
            // Helpers
            Mapper.CreateMap<List<Product>, int>().ConvertUsing(list => list.Count);
            Mapper.CreateMap<List<PageStyle>, int>().ConvertUsing(list => list.Count);
            Mapper.CreateMap<List<Shop>, int>().ConvertUsing(list => list.Count);
            Mapper.CreateMap<Image, string>().ConvertUsing(img => img.Source());
            Mapper.CreateMap<PageStyle, int>().ConvertUsing(s => s != null ? s.Id : 0);
            Mapper.CreateMap<PageLayout, int>().ConvertUsing(l => l != null ? l.Id : 0);

            // Models

            Mapper.CreateMap<User, IndexViewModel>()
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.ProfileImage()));

            Mapper.CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.ProfileImage()))
                .ForMember(dest => dest.Blocked, opt => opt.MapFrom(src => src.IsBlocked()));

            Mapper.CreateMap<PageLayout, PageLayoutViewModel>();
            
            Mapper.CreateMap<Category, CategoryViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (int)src.Id));

            Mapper.CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(c => c.Id.ToString()).ToArray()));

            Mapper.CreateMap<PageStyle, PageStyleViewModel>();
            
            Mapper.CreateMap<Shop, ShopViewModel>();
        }
    }
}