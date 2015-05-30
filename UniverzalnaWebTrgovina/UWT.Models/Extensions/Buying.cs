using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWT.Models.Extensions {
    public static class Buying {

        /// <summary>
        /// Checks if there are enough products in the inventory and reserves them
        /// </summary>
        /// <param name="basket"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool ReserveProducts(this Basket basket, UwtContext db)
        {
            // Check if there are enough products available
            if (basket != null && basket.BasketItems.Any() && !basket.BasketItems.Any(b => b.Product.Count < b.Amount))
            {
                // Remove products from inventory
                basket.BasketItems.ForEach(b => b.Product.Count -= b.Amount);
                return true;
            }
            return false;
        }

    }
}
