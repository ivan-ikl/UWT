﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UWT.Models;
using UWT.Models.Extensions;
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
            MapSerializationModels();
        }

        private static void MapViewModelsToModels()
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
                .ForMember(dest => dest.Owner, opt => opt.Ignore())
                .ForMember(dest => dest.Discount, opt => opt.Ignore());

            Mapper.CreateMap<ProductViewModel, Product>()
                .ForMember(dest => dest.Shop, opt => opt.Ignore())
                .ForMember(dest => dest.Categories, opt => opt.Ignore());
        }

        private static void MapModelsToViewModels()
        {
            // Helpers
            Mapper.CreateMap<List<Product>, int>().ConvertUsing(list => list.Count);
            Mapper.CreateMap<List<PageStyle>, int>().ConvertUsing(list => list.Count);
            Mapper.CreateMap<List<Shop>, int>().ConvertUsing(list => list.Count);
            Mapper.CreateMap<Image, string>().ConvertUsing(img => img.Source());
            Mapper.CreateMap<PageStyle, int>().ConvertUsing(s => s != null ? s.Id : 0);
            Mapper.CreateMap<PageLayout, int>().ConvertUsing(l => l != null ? l.Id : 0);
            Mapper.CreateMap<BasketItem, BasketItemViewModel>();
            Mapper.CreateMap<Basket, BasketViewModel>()
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.Owner.Id))
                .ForMember(dest => dest.Invoice, opt => opt.MapFrom(src => src.Invoice != null ? src.Invoice.Id : 0));
            Mapper.CreateMap<Invoice, InvoiceViewModel>();

            // Models

            Mapper.CreateMap<User, IndexViewModel>()
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.ProfileImage()));

            Mapper.CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.ProfileImage()))
                .ForMember(dest => dest.Blocked, opt => opt.MapFrom(src => src.IsBlocked()));

            Mapper.CreateMap<PageLayout, PageLayoutViewModel>();

            Mapper.CreateMap<Category, CategoryViewModel>();

            Mapper.CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Categories,
                    opt => opt.MapFrom(src => src.Categories.Select(c => c.Id.ToString()).ToArray()))
                .ForMember(dest => dest.DiscountedPrice, opt => opt.MapFrom(src => src.DiscountedPrice()));

            Mapper.CreateMap<PageStyle, PageStyleViewModel>();

            Mapper.CreateMap<Shop, ShopViewModel>();

            // Discount model
            Mapper.CreateMap<Product, ProductDiscountModel>()
                .ForMember(dest => dest.Categories, opt => opt.Ignore())
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => (int) (src.Discount*100)));

            Mapper.CreateMap<Category, CategoryDiscountModel>()
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => (int) (src.Discount*100)));

            Mapper.CreateMap<Shop, ShopDiscountModel>()
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => (int) (src.Discount*100)));
        }

        public static void MapSerializationModels()
        {
            Mapper.CreateMap<Product, Portable.Models.Product>()
                .ForMember(dest => dest.DiscountedPrice, opt => opt.MapFrom(src => src.DiscountedPrice()))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image.Path))
                .ForMember(dest => dest.DailySails, opt => opt.Ignore())
                .ForMember(dest => dest.Messages, opt => opt.Ignore());
            Mapper.CreateMap<Category, Portable.Models.Category>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image.Path));
            Mapper.CreateMap<Shop, Portable.Models.Shop>()
                .ForMember(dest => dest.Logo, opt => opt.MapFrom(src => src.PageStyle.Logo.Path));
        }
    }
}