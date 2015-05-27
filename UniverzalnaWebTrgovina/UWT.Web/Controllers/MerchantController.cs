using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.Mappers;
using Microsoft.AspNet.Identity;
using UWT.Models;
using UWT.Web.Extensions;
using UWT.Web.Helpers;
using UWT.Web.Models;

namespace UWT.Web.Controllers
{
    [Authorize(Roles=Roles.Merchant)]
    public class MerchantController : Controller
    {
        // GET: Merchant
        public ActionResult PageStyles()
        {
            string userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                return View(Enumerable.ToList(db.PageStyles.Filter(userId).ToList().Select(Mapper.Map<PageStyleViewModel>)));
            }
        }

        public ActionResult CreatePageStyle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePageStyle(PageStyleViewModel model, HttpPostedFileBase imglogo, HttpPostedFileBase imgbackground, HttpPostedFileBase imgnav, HttpPostedFileBase imgfooter) {
            if (ModelState.IsValid)
            {
                var pageStyle = Mapper.Map<PageStyle>(model);
                var userId = User.Identity.GetUserId();
                using (var db = new UwtContext())
                {
                    pageStyle.Logo = db.AddUploadedImage(imglogo, Server, userId);
                    pageStyle.BackgroundImage = db.AddUploadedImage(imgbackground, Server, userId);
                    pageStyle.NavImage = db.AddUploadedImage(imgnav, Server, userId);
                    pageStyle.FooterImage = db.AddUploadedImage(imgfooter, Server, userId);
                    pageStyle.Owner = db.Users.FirstOrDefault(u => u.Id == userId);
                    pageStyle.DateCreated = DateTime.UtcNow;
                    db.PageStyles.Add(pageStyle);
                }
                return RedirectToAction("PageStyles");
            }
            return View(model);
        }

        public ActionResult EditPageStyle(int Id) {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                var pageStyle = db.PageStyles.Filter(userId).FirstOrDefault(ps => ps.Id == Id);
                if (pageStyle == null)
                {
                    return HttpNotFound();
                }
                return View(Mapper.Map<PageStyleViewModel>(pageStyle));
            }
        }

        [HttpPost]
        public ActionResult EditPageStyle(PageStyleViewModel model, HttpPostedFileBase imglogo, HttpPostedFileBase imgbackground, HttpPostedFileBase imgnav, HttpPostedFileBase imgfooter) {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                using (var db = new UwtContext())
                {
                    var pageStyle = db.PageStyles.Filter(userId).FirstOrDefault(ps => ps.Id == model.Id);
                    if (pageStyle == null)
                    {
                        return HttpNotFound();
                    }                    
                    return View(Mapper.Map<PageStyleViewModel>(pageStyle));
                }
            }
            return View(model);
        }
    }
}