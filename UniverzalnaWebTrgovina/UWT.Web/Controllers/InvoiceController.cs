using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using UWT.Models;
using UWT.Models.Extensions;
using UWT.Web.Extensions;
using UWT.Web.Models;

namespace UWT.Web.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        public ActionResult Index(int id)
        {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                var shop = db.Shops.FirstOrDefault(s => s.Id == id);
                if (shop == null) return HttpNotFound();

                var invoices = db.Invoices.IncludeAll().Filter(userId, id).ToList();
                var model = invoices.Select(Mapper.Map<InvoiceViewModel>).ToList();
                ViewBag.Shop = Mapper.Map<ShopViewModel>(shop);
                return View(model);
            }
        }

        public ActionResult Invoice(int id)
        {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                var invoice = db.Invoices.IncludeAll().Filter(userId).FirstOrDefault(i => i.Id == id);
                if (invoice == null) return HttpNotFound();

                ViewBag.Shop = Mapper.Map<ShopViewModel>(invoice.GetShop(db));
                var model = Mapper.Map<InvoiceViewModel>(invoice);
                return View(model);
            }
        }
    }
}