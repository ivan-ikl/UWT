using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using UWT.Models;
using UWT.Models.Extensions;
using UWT.Web.Extensions;
using UWT.Web.Models;

namespace UWT.Web.Controllers {

    public class HomeController : Controller {

        public ActionResult Index(int? id, int? category, string search) {
            using (var db = new UwtContext())
            {
                var shop = db.Shops.FirstOrDefault(s => s.Id == id);
                if (shop == null) {
                    var shops = db.Shops.ToList().Select(Mapper.Map<ShopViewModel>).ToList();
                    return View(shops);
                }
                var model = Mapper.Map<ShopViewModel>(shop);
                var products = db.Products.Filter(model.Id).Where(p => category == null || p.Categories.FirstOrDefault(c => c.Id == category) != null).ToList().Select(Mapper.Map<ProductViewModel>).ToList();
                if (User.Identity.IsAuthenticated)
                {
                    var userId = User.Identity.GetUserId();
                    products.ForEach(p => p.InBasket = p.InBasket(userId, shop.Id));
                    ViewBag.BasketItemsCount = db.GetCurrentBasket(userId, shop.Id).BasketItems.Count;
                }
                ViewBag.Products = products;
                return View("Shop", model);
            }
        }

        public ActionResult About() {
            return View();
        }

        public ActionResult Contact() {
            return View();
        }

    }
}