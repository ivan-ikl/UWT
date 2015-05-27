using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using UWT.Models;
using UWT.Models.Extensions;
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
                return View(db.PageStyles.IncludeAll().Filter(userId).ToList().Select(Mapper.Map<PageStyleViewModel>).ToList());
            }
        }

        public ActionResult CreatePageStyle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    db.SaveChanges();
                }
                return RedirectToAction("PageStyles");
            }
            return View(model);
        }

        public ActionResult EditPageStyle(int Id) {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                var pageStyle = db.PageStyles.IncludeAll().Filter(userId).FirstOrDefault(ps => ps.Id == Id);
                if (pageStyle == null)
                {
                    return HttpNotFound();
                }
                return View(Mapper.Map<PageStyleViewModel>(pageStyle));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPageStyle(PageStyleViewModel model, HttpPostedFileBase imglogo, HttpPostedFileBase imgbackground, HttpPostedFileBase imgnav, HttpPostedFileBase imgfooter) {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                using (var db = new UwtContext())
                {
                    var pageStyle = db.PageStyles.IncludeAll().Filter(userId).FirstOrDefault(ps => ps.Id == model.Id);
                    if (pageStyle == null)
                    {
                        return HttpNotFound();
                    }
                    pageStyle.Update(model, imglogo, imgbackground, imgnav, imgfooter, Server);
                    db.SaveChanges();
                }
                return RedirectToAction("EditPageStyle", "Merchant", new {model.Id});
            }
            return View(model);
        }

        public ActionResult MyShops()
        {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                return View(db.Shops.IncludeAll().Filter(userId).ToList().Select(Mapper.Map<ShopViewModel>));
            }
        }

        public ActionResult CreateShop()
        {
            string userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                var pageStyles = db.PageStyles.Filter(userId).ToList();
                var pageLayouts = db.PageLayouts.Filter(userId).ToList();
                ViewBag.PageStyles = new SelectList(pageStyles, "Id", "Name");
                ViewBag.PageLayouts = new SelectList(pageLayouts, "Id", "Name");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateShop(ShopViewModel model)
        {
            string userId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                var shop = Mapper.Map<Shop>(model);
                using (var db = new UwtContext())
                {
                    shop.Owner = db.Users.FirstOrDefault(u => u.Id == userId);
                    shop.DateCreated = DateTime.UtcNow;
                    shop.PageStyle = db.PageStyles.FirstOrDefault(p => p.Id == model.PageStyle);
                    shop.PageLayout = db.PageLayouts.FirstOrDefault(p => p.Id == model.PageLayout);
                    db.Shops.Add(shop);
                    db.SaveChanges();
                }
                return RedirectToAction("MyShops");
            }
            using (var db = new UwtContext()) {
                var pageStyles = db.PageStyles.Filter(userId).ToList();
                var pageLayouts = db.PageLayouts.Filter(userId).ToList();
                ViewBag.PageStyles = new SelectList(pageStyles, "Id", "Name");
                ViewBag.PageLayouts = new SelectList(pageLayouts, "Id", "Name");
            }
            return View(model);
        }

        public ActionResult EditShop(int Id)
        {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                var shop = db.Shops.Filter(userId).FirstOrDefault(s => s.Id == Id);
                if (shop == null)
                {
                    return HttpNotFound();
                }
                var model = Mapper.Map<ShopViewModel>(shop);
                var pageStyles = db.PageStyles.Filter(userId).ToList();
                var pageLayouts = db.PageLayouts.Filter(userId).ToList();
                ViewBag.PageStyles = new SelectList(pageStyles, "Id", "Name", model.PageStyle);
                ViewBag.PageLayouts = new SelectList(pageLayouts, "Id", "Name", model.PageLayout);
                return View(model);
            }
        }

        public ActionResult EditShop(ShopViewModel model) {
            var userId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                using (var db = new UwtContext())
                {
                    var shop = db.Shops.Filter(userId).FirstOrDefault(s => s.Id == model.Id);
                    if (shop == null)
                    {
                        return HttpNotFound();
                    }

                    var style = db.PageStyles.FirstOrDefault(s => s.Id == model.PageStyle);
                    var layout = db.PageLayouts.FirstOrDefault(l => l.Id == model.PageLayout);
                    shop.Update(model, style, layout);

                    return RedirectToAction("EditShop", "Merchant", new {model.Id});
                }
            }
            using (var db = new UwtContext()) 
            {
                var pageStyles = db.PageStyles.Filter(userId).ToList();
                var pageLayouts = db.PageLayouts.Filter(userId).ToList();
                ViewBag.PageStyles = new SelectList(pageStyles, "Id", "Name", model.PageStyle);
                ViewBag.PageLayouts = new SelectList(pageLayouts, "Id", "Name", model.PageLayout);
            }
            return View(model);
        }

    }
}