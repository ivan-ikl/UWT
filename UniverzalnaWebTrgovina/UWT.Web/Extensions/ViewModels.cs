using System.Linq;
using UWT.Models;
using UWT.Models.Extensions;
using UWT.Web.Models;

namespace UWT.Web.Extensions {
    public static class ViewModels {
        public static bool InBasket(this ProductViewModel product, string userId, int shop)
        {
            using (var db = new UwtContext())
            {
                var basket = db.GetCurrentBasket(userId, shop);
                return basket.BasketItems.FirstOrDefault(b => b.Product.Id == product.Id) != null;
            }
        }

        public static double TotalPrice(this InvoiceViewModel invoice)
        {
            return invoice.Basket.BasketItems.Sum(i => i.Amount * i.UnitPrice);
        }

        public static double TotalPrice(this BasketItemViewModel item)
        {
            return item.UnitPrice.Round(2)*item.Amount;
        }

        public static double TotalDiscount(this ProductViewModel product)
        {
            return product.UnitPrice > 0 ? (1 - product.DiscountedPrice/product.UnitPrice).Round(2) : 0;
        }
    }
}