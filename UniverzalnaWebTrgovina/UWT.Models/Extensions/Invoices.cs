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

    }
}