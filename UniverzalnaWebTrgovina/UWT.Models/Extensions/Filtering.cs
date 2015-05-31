using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace UWT.Models.Extensions {
    public static class Filtering 
    {
        public static IQueryable<PageStyle> Filter(this IQueryable<PageStyle> items, string userId)
        {
            return items.Where(i => i.Owner != null && i.Owner.Id == userId);
        }

        public static IQueryable<Shop> Filter(this IQueryable<Shop> items, string userId)
        {
            return items.Where(i => i.Owner != null && i.Owner.Id == userId);
        }

        public static IQueryable<Category> Filter(this IQueryable<Category> items, string userId, int shopId)
        {
            return items.Where(i => i.Shop != null && i.Shop.Owner != null && i.Shop.Owner.Id == userId && i.Shop.Id == shopId);
        }

        public static IQueryable<Product> Filter(this IQueryable<Product> items, string userId, int shopId)
        {
            return items.Where(i => i.Shop != null && i.Shop.Owner != null && i.Shop.Owner.Id == userId && i.Shop.Id == shopId);
        }

        public static IQueryable<Product> Filter(this IQueryable<Product> items,  int shopId) 
        {
            return items.Where(i => i.Shop != null && i.Shop.Id == shopId);
        }

        public static IQueryable<Category> Filter(this IQueryable<Category> items, int shopId)
        {
            return items.Where(i => i.Shop != null && i.Shop.Id == shopId);
        }

        public static IQueryable<Basket> Filter(this IQueryable<Basket> items, string userId)
        {
            return items.Where(i => i.Owner != null && i.Owner.Id == userId);
        }

        public static IQueryable<Basket> Filter(this IQueryable<Basket> items, string userId, int shopId)
        {
            return items.Filter(userId).Filter(shopId);
        }

        public static IQueryable<Basket> Filter(this IQueryable<Basket> items, int shopId)
        {                              
            // Baskets without basketitems belong to all shops
            return items.Where(i => !i.BasketItems.Any() || i.BasketItems.FirstOrDefault().Product.Shop.Id == shopId);
        }

        public static IQueryable<Basket> OpenBaskets(this IQueryable<Basket> items)
        {
            return items.Where(i => i.DateClosed > DateTime.UtcNow && i.Invoice == null);
        }

        public static IQueryable<Invoice> Filter(this IQueryable<Invoice> items, string userId, int shopId)
        {
            return items.Filter(userId).Filter(shopId);
        }

        public static IQueryable<Invoice> Filter(this IQueryable<Invoice> items, int shopId)
        {
            return items.Where(i => i.Basket.BasketItems.FirstOrDefault().Product.Shop.Id == shopId);
        }

        public static IQueryable<Invoice> Filter(this IQueryable<Invoice> items, string userId) 
        {
            return items.Where(i => i.Basket.Owner.Id == userId);
        }

        public static IQueryable<Invoice> Filter(this IQueryable<Invoice> items, DateTime start, DateTime end)
        {
            return items.Where(i => i.DateCreated >= start && i.DateCreated < end);
        }

        public static IQueryable<Invoice> FilterByShopOwner(this IQueryable<Invoice> items, string userId)
        {
            return items.Where(i => i.Basket.BasketItems.FirstOrDefault().Product.Shop.Owner.Id == userId);            
        }

    }
}