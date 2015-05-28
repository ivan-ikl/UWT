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
    }
}