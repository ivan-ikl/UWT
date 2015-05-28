using System.Web.Mvc;
using System.Web.Security;
using Roles = UWT.Models.Roles;

namespace UWT.Web.Controllers {

    [Authorize]
    public class HomeController : Controller {
        public ActionResult Index() {
            if (User.IsInRole(Roles.Admin))
            {
                return RedirectToAction("Index", "Admin");
            }
            if (User.IsInRole(Roles.Merchant))
            {
                return RedirectToAction("MyShops", "Merchant");
            }
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

}