﻿using System.Data.Entity;
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
    }
}
