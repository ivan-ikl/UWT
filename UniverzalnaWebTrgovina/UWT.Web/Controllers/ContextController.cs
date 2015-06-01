using System.Linq;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using UWT.Models;
using UWT.Models.Extensions;
using UWT.Web.Extensions;
using WebGrease.Css.Extensions;

namespace UWT.Web.Controllers
{
    public class ContextController : ApiController
    {
        public Portable.Models.UwtContext GetAppContext() {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext()) {
                var context = new Portable.Models.UwtContext {
                    Shops = db.Shops.IncludeAll().Filter(userId).ToList().Select(Mapper.Map<Portable.Models.Shop>).ToArray()
                };
                context.Shops.ForEach(s => s.Categories.ForEach(c => c.Products.ForEach(p => p.NumberSold = db.Invoices.ProductsSold(p.Id))));
                return context;
            }
        }

    }
}
