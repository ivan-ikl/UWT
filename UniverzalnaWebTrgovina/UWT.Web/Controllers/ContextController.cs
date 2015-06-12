using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using UWT.Models;
using UWT.Models.Extensions;
using UWT.Web.Extensions;
using UWT.Web.Models;
using WebGrease.Css.Extensions;

namespace UWT.Web.Controllers
{
    public class ContextController : ApiController
    {
        [AcceptVerbs("GET", "POST")]
        [SuppressMessage("ReSharper", "AccessToDisposedClosure")]
        public async Task<Portable.Models.UwtContext> GetAppContext(string email = "", string password = "")
        {
            // Sign the user in and return null if that isn't possible
            var signInManager = Request.GetOwinContext().Get<UwtSignInManager>();
            var blocked = new LoginViewModel {Email = email, Password = password}.IsBlocked();
            if (blocked || await signInManager.PasswordSignInAsync(email, password, false, false) != SignInStatus.Success)
            {
                return new Portable.Models.UwtContext();
            }

            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext()) {
                var context = new Portable.Models.UwtContext {
                    Shops = db.Shops.IncludeAll().Filter(userId).ToList().Select(Mapper.Map<Portable.Models.Shop>).ToArray()
                };
                context.Shops.ForEach(s => s.Categories.ForEach(c => c.Products.ForEach(p =>
                {
                    p.NumberSold = db.Invoices.ProductsSold(p.Id);
                    p.Messages = db.Messages.Filter(userId, p.Id).ActiveMessages().Count();
                    p.DailySails = db.GetDailySales(p.Id, 10);
                })));
                return context;
            }
        }

    }
}
