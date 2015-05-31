using System;
using System.Linq;

namespace UWT.Models.Extensions {
    public static class Discounts {

        public static double GetDiscount(this Product product)
        {
            try
            {
                return new[] {product.Discount, product.Categories.Max(c => c.Discount), product.Shop.Discount}.Max();
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine("Cannot get discount for product ({1}) {0}", product.Title, product.Id);
                return 0;
            }
        }

        public static double DiscountedPrice(this Product product)
        {
            return Math.Round(product.UnitPrice * (1 - product.GetDiscount()), 2);
        }

    }
}
