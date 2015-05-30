using System.Linq;
using System.Web.Mvc;
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
            return invoice.Basket.BasketItems.Sum(i => i.Amount*i.UnitPrice);
        }
    }
}