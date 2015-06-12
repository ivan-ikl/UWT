using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UWT.Models.Extensions {
    public static class UwtContextExtensions {

        public static Basket GetCurrentBasket(this UwtContext db, string userId, int shopId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            var shop = db.Shops.FirstOrDefault(s => s.Id == shopId);
            if (user == null || shop == null) return null;

            var basket = db.Baskets.OpenBaskets().Filter(userId, shopId).IncludeAll().FirstOrDefault();
            if (basket == null) {
                basket = new Basket {
                    DateCreated = DateTime.UtcNow,
                    DateClosed = DateTime.MaxValue,
                    Owner = user,
                    BasketItems = new List<BasketItem>(),
                    DeliveryPerson = user.Name + " " + user.Surname,
                    DeliveryAddress = user.Address,
                    Invoice = null
                };
                db.Baskets.Add(basket);
            }
            return basket;
        }

        public static int[][] GetDailySales(this UwtContext db, int productId, int days)
        {
            var sales = db.BasketItems.Where(b => b.Product.Id == productId && b.Basket.Invoice != null && DbFunctions.DiffDays(DateTime.UtcNow, b.Basket.Invoice.DateCreated) <= days).ToList().Select(b => new[] { days + (int)(b.Basket.Invoice.DateCreated.ToLocalTime().Date - DateTime.UtcNow.Date).TotalDays, b.Amount }).ToList();
            return Enumerable.Range(1, days).Select(e => new[] { e, sales.Where(s => s[0] == e).Sum(s => s[1]) }).ToArray();
        } 

    }
}
