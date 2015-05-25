using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using UWT.Models;
using UWT.Web.Extensions;
using UWT.Web.Models;

namespace UWT.Web.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (var db = new UwtContext())
            {

                return View("Users", db.Users.Include(u => u.ProfileImages).ToList().Select(Mapper.Map<UserViewModel>));
            }
        }

        [HttpPost]
        public bool BlockUser(string email)
        {
            using (var db = new UwtContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email);
                if (user != null && user.UserName != "admin" && !user.IsBlocked())
                {
                    user.Block();
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        [HttpPost]
        public bool UnblockUser(string email)
        {
            using (var db = new UwtContext()) {
                var user = db.Users.FirstOrDefault(u => u.Email == email);
                if (user != null && user.IsBlocked()) {
                    user.Unblock();
                    db.SaveChanges();
                    return true;
                }
            }
            return false;            
        }

    }
}