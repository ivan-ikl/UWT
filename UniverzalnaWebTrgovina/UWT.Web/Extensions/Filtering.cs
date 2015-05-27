using System.Linq;
using UWT.Models;
using UWT.Models.Interfaces;

namespace UWT.Web.Extensions {
    public static class Filtering 
    {
        public static IQueryable<PageStyle> Filter(this IQueryable<PageStyle> items, string userId)
        {
            return items.Where(i => i.Owner != null && i.Owner.Id == userId);
        }

        public static IQueryable<PageLayout> Filter(this IQueryable<PageLayout> items, string userId)
        {
            return items.Where(i => i.Owner != null && i.Owner.Id == userId);
        }

        public static IQueryable<Shop> Filter(this IQueryable<Shop> items, string userId)
        {
            return items.Where(i => i.Owner != null && i.Owner.Id == userId);
        } 

    }
}