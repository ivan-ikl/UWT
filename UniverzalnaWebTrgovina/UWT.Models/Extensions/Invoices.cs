using System;
using System.Linq;
using UWT.Models;
using UWT.Models.Extensions;

namespace UWT.Web.Extensions {
    public static class Invoices {

        public static Shop GetShop(this Invoice invoice, UwtContext db)
        {
            var basketItem = invoice.Basket.BasketItems.FirstOrDefault();
            if (basketItem == null) return null;

            var shopId = basketItem.Product.Shop.Id;
            return db.Shops.IncludeAll().FirstOrDefault(s => s.Id == shopId);
        }

        public static int ProductsSold(this IQueryable<Invoice> invoices, int productId)
        {
            try
            {
                return invoices.Select(i => i.Basket.BasketItems.FirstOrDefault(b => b.Product.Id == productId)).Where(b => b != null).Sum(b => b.Amount);
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}