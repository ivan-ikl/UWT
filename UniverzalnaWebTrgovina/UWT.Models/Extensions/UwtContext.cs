using System;
using System.Collections.Generic;
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
                    Invoice = null
                };
                db.Baskets.Add(basket);
            }
            return basket;
        }

    }
}
