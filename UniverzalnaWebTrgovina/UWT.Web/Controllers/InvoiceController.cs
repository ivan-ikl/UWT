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
    public class InvoiceController : Controller
    {

        public ActionResult Invoice(int id)
        {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                var invoice = db.Invoices.IncludeAll().Filter(userId).FirstOrDefault(i => i.Id == id);
                if (invoice == null) return HttpNotFound();

                var model = Mapper.Map<InvoiceViewModel>(invoice);
                return View(model);
            }
        }
    }
}