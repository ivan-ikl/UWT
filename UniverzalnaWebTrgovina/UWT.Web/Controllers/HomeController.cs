using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using UWT.Models;
using UWT.Web.Models;

namespace UWT.Web.Controllers {

    public class HomeController : Controller {
        public ActionResult Index(int? id) {
            if (id == null)
            {
                if (User.IsInRole(Roles.Admin))
                {
                    return RedirectToAction("Index", "Admin");
                }
                if (User.IsInRole(Roles.Merchant))
                {
                    return RedirectToAction("MyShops", "Merchant");
                }
            }
            using (var db = new UwtContext())
            {
                var shop = db.Shops.FirstOrDefault(s => s.Id == id);
                if (shop == null) {
                    var shops = db.Shops.ToList().Select(Mapper.Map<ShopViewModel>).ToList();
                    return View(shops);
                }
                var model = Mapper.Map<ShopViewModel>(shop);
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