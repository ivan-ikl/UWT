using System.Linq;
using UWT.Models.Interfaces;

namespace UWT.Web.Extensions {
    public static class Filtering 
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> items, string userId) where T : IUserOwned
        {
            return items.Where(i => i.Owner != null && i.Owner.Id == userId);
        } 
    }
}