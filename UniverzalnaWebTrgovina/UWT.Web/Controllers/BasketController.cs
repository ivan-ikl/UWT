using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using UWT.Models;
using UWT.Models.Extensions;
using UWT.Web.Models;

namespace UWT.Web.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        public bool AddToBasket(int product, int shop)
        {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                var dbProduct = db.Products.Filter(shop).FirstOrDefault(p => p.Id == product);
                if (dbProduct == null) return false;
                var basket = db.GetCurrentBasket(userId, shop);
                if (basket.BasketItems.FirstOrDefault(i => i.Product.Id == product) != null) return false;

                db.BasketItems.Add(new BasketItem()
                {
                    Amount = 1,
                    Product = dbProduct,
                    UnitPrice = dbProduct.DiscountedPrice(),
                    DiscountedFrom = dbProduct.UnitPrice,
                    Basket = basket
                });
                db.SaveChanges();
                return true;
            }
        }

        public bool RemoveFromBasket(int product)
        {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                var dbProduct = db.Products.IncludeAll().FirstOrDefault(p => p.Id == product);
                if (dbProduct == null) return false;

                var basket = db.GetCurrentBasket(userId, dbProduct.Shop.Id);
                var item = basket.BasketItems.FirstOrDefault(i => i.Product.Id == product);
                if (item == null) return false;
                db.BasketItems.Remove(item);
                db.SaveChanges();
                return true;
            }
        }

        public bool UpdateBasketAmount(int product, int newAmount)
        {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                var dbProduct = db.Products.IncludeAll().FirstOrDefault(p => p.Id == product);
                if (dbProduct == null) return false;

                var basket = db.GetCurrentBasket(userId, dbProduct.Shop.Id);
                var item = basket.BasketItems.FirstOrDefault(i => i.Product.Id == product);
                if (item == null) return false;
                item.Amount = newAmount;
                db.SaveChanges();
                return true;
            }
        }

        public ActionResult Index(int shop)
        {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                var basket = db.GetCurrentBasket(userId, shop);
                if (basket != null)
                {
                    ViewBag.Shop = Mapper.Map<ShopViewModel>(db.Shops.FirstOrDefault(s => s.Id == shop));
                    var model = Mapper.Map<BasketViewModel>(basket);
                    model.BasketItems.ForEach(i => i.Product.Image = i.Product.Image.Replace("~", ""));
                    return View(model);
                }
                return HttpNotFound();
            }            
        }

        [HttpPost]
        public ActionResult Index(int shop, string deliveryaddress, string deliveryperson)
        {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext()) {
                var basket = db.GetCurrentBasket(userId, shop);
                if (basket != null)
                {
                    basket.DeliveryAddress = deliveryaddress;
                    basket.DeliveryPerson = deliveryperson;
                    db.SaveChanges();
                }
                return RedirectToAction("Index", new {shop = shop});
            }                        
        }

        [HttpPost]
        public int BuyBasket(int shop)
        {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext()) {
                var basket = db.GetCurrentBasket(userId, shop);
                if (!basket.ReserveProducts(db))
                {
                    return 0;
                }                
                var invoice = new Invoice {Basket = basket, DateCreated = DateTime.UtcNow};
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return invoice.Id;
            }                        
        }
    }
}