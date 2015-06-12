using System.Data.Entity;
using System.Linq;

namespace UWT.Models.Extensions {
    public static class Entities {
        public static IQueryable<PageStyle> IncludeAll(this IQueryable<PageStyle> pageStyles)
        {
            return
                pageStyles.Include(ps => ps.Shops)
                    .Include(ps => ps.BackgroundImage)
                    .Include(ps => ps.FooterImage)
                    .Include(ps => ps.Logo)
                    .Include(ps => ps.NavImage)
                    .Include(ps => ps.Owner);
        }

        public static IQueryable<PageLayout> IncludeAll(this IQueryable<PageLayout> layouts)
        {
            return layouts.Include(l => l.Owner).Include(l => l.Shops);
        }

        public static IQueryable<Shop> IncludeAll(this IQueryable<Shop> shops)
        {
            return shops.Include(s => s.PageLayout).Include(s => s.PageStyle).Include(s => s.Owner);
        }

        public static IQueryable<Category> IncludeAll(this IQueryable<Category> categories)
        {
            return categories.Include(c => c.Shop).Include(c => c.Image).Include(c => c.Products);
        }

        public static IQueryable<Product> IncludeAll(this IQueryable<Product> products)
        {
            return products.Include(p => p.Shop).Include(p => p.Categories).Include(p => p.Image).Include(p => p.Orders).Include(p => p.Messages);
        }

        public static IQueryable<Basket> IncludeAll(this IQueryable<Basket> baskets)
        {
            return baskets.Include(b => b.BasketItems.Select(i => i.Product)).Include(b => b.BasketItems.Select(i => i.Product.Image)).Include(b => b.Invoice).Include(b => b.Owner);
        }

        public static IQueryable<Invoice> IncludeAll(this IQueryable<Invoice> invoices)
        {
            return invoices.Include(i => i.Basket.BasketItems.Select(b => b.Product.Image));
        }

        public static IQueryable<Message> IncludeAll(this IQueryable<Message> messages)
        {
            return messages.Include(m => m.Product).Include(m => m.Sender).Include(m => m.Reciever);
        }
    }
}
