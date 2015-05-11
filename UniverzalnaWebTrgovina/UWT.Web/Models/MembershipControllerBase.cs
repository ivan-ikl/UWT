using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace UWT.Web {

    public abstract class MembershipControllerBase : Controller {
        protected UwtUserManager _userManager = null;
        protected UwtSignInManager _signInManager = null;

        public UwtSignInManager SignInManager {
            get {
                return _signInManager ?? HttpContext.GetOwinContext().Get<UwtSignInManager>();
            }
            set {
                _signInManager = value;
            }

        }

        public UwtUserManager UserManager {
            get {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UwtUserManager>();
            }
            set {
                _userManager = value;
            }
        }

    }

}