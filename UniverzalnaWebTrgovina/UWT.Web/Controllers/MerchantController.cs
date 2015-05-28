using System;
using System.Collections.Generic;
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
                var pageLayouts = db.PageLayouts.ToList();
                ViewBag.PageStyles = pageStyles.Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString() });
                ViewBag.PageLayouts = pageLayouts.Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString() });
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
                    shop.PageStyle = db.PageStyles.Filter(userId).FirstOrDefault(p => p.Id == model.PageStyle);
                    shop.PageLayout = db.PageLayouts.FirstOrDefault(p => p.Id == model.PageLayout);
                    db.Shops.Add(shop);
                    db.SaveChanges();
                }
                return RedirectToAction("MyShops");
            }
            using (var db = new UwtContext()) {
                var pageStyles = db.PageStyles.Filter(userId).ToList();
                var pageLayouts = db.PageLayouts.ToList();
                ViewBag.PageStyles = pageStyles.Select(i => new SelectListItem {Text = i.Name, Value = i.Id.ToString()});
                ViewBag.PageLayouts = pageLayouts.Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString()});
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
                var pageLayouts = db.PageLayouts.ToList();
                ViewBag.PageStyles = pageStyles.Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString(), Selected = i.Id == model.PageStyle});
                ViewBag.PageLayouts = pageLayouts.Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString(), Selected = i.Id == model.PageLayout});
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditShop(ShopViewModel model) {
            var userId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                using (var db = new UwtContext())
                {
                    var shop = db.Shops.IncludeAll().Filter(userId).FirstOrDefault(s => s.Id == model.Id);
                    if (shop == null)
                    {
                        return HttpNotFound();
                    }

                    var style = db.PageStyles.Filter(userId).FirstOrDefault(s => s.Id == model.PageStyle);
                    var layout = db.PageLayouts.FirstOrDefault(l => l.Id == model.PageLayout);
                    shop.Update(model, style, layout);
                    db.SaveChanges();
                }
                return RedirectToAction("EditShop", "Merchant", new { model.Id });
            }
            using (var db = new UwtContext()) 
            {
                var pageStyles = db.PageStyles.Filter(userId).ToList();
                var pageLayouts = db.PageLayouts.ToList();
                ViewBag.PageStyles = pageStyles.Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString(), Selected = i.Id == model.PageStyle });
                ViewBag.PageLayouts = pageLayouts.Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString(), Selected = i.Id == model.PageLayout });
            }
            return View(model);
        }

        public ActionResult Categories(int shop)
        {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext())
            {
                var myShop = db.Shops.Filter(userId).FirstOrDefault(s => s.Id == shop);
                if (myShop == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ShopName = myShop.Name;
                ViewBag.ShopId = myShop.Id;
                var categories = db.Categories.Filter(userId).ToList().Select(Mapper.Map<CategoryViewModel>).ToList();
                return View(categories);
            }
        }

        public ActionResult CreateCategory(int shop)
        {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext()) {
                var myShop = db.Shops.Filter(userId).FirstOrDefault(s => s.Id == shop);
                if (myShop == null) {
                    return HttpNotFound();
                }
                ViewBag.ShopName = myShop.Name;
                ViewBag.ShopId = myShop.Id;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory([Bind(Exclude = "Shop")] CategoryViewModel model, int shop, HttpPostedFileBase image)
        {
            var userId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                var category = Mapper.Map<Category>(model);
                using (var db = new UwtContext())
                {
                    var myShop = db.Shops.Filter(userId).FirstOrDefault(s => s.Id == shop);
                    if (myShop == null)
                    {
                        return HttpNotFound();
                    }
                    category.Shop = myShop;
                    category.Image = image.AddUploadedImage(Server, db.Users.FirstOrDefault(u => u.Id == userId));
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Categories", "Merchant", new {shop = myShop.Id});
                }
            }
            using (var db = new UwtContext())
            {
                var myShop = db.Shops.Filter(userId).FirstOrDefault(s => s.Id == shop);
                if (myShop == null) {
                    return HttpNotFound();
                }
                ViewBag.ShopName = myShop.Name;
                ViewBag.ShopId = myShop.Id;                
            }
            return View(model);
        }

        public ActionResult EditCategory(int shop, int id)
        {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext()) {
                var myShop = db.Shops.Filter(userId).FirstOrDefault(s => s.Id == shop);
                var category = db.Categories.Filter(userId).FirstOrDefault(c => c.Id == id);
                if (myShop == null || category == null) {
                    return HttpNotFound();
                }
                ViewBag.ShopName = myShop.Name;
                ViewBag.ShopId = myShop.Id;
                return View(Mapper.Map<CategoryViewModel>(category));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory([Bind(Exclude = "Shop")] CategoryViewModel model, int shop, HttpPostedFileBase image) {
            var userId = User.Identity.GetUserId();
            if (ModelState.IsValid) {
                using (var db = new UwtContext()) {
                    var myShop = db.Shops.Filter(userId).FirstOrDefault(s => s.Id == shop);
                    var category = db.Categories.IncludeAll().Filter(userId).FirstOrDefault(c => c.Id == model.Id);
                    if (myShop == null || category == null) {
                        return HttpNotFound();
                    }
                    category.Name = model.Name;
                    if (image != null && image.ContentLength > 0)
                    {
                        category.Image = image.AddUploadedImage(Server, db.Users.FirstOrDefault(u => u.Id == userId));
                    }
                    db.SaveChanges();
                    return RedirectToAction("EditCategory", "Merchant", new { shop = myShop.Id, Id = model.Id });
                }
            }
            using (var db = new UwtContext()) {
                var myShop = db.Shops.Filter(userId).FirstOrDefault(s => s.Id == shop);
                if (myShop == null) {
                    return HttpNotFound();
                }
                ViewBag.ShopName = myShop.Name;
                ViewBag.ShopId = myShop.Id;
            }
            return View(model);
        }

        public ActionResult Products(int shop) {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext()) {
                var myShop = db.Shops.Filter(userId).FirstOrDefault(s => s.Id == shop);
                if (myShop == null) {
                    return HttpNotFound();
                }
                ViewBag.ShopName = myShop.Name;
                ViewBag.ShopId = myShop.Id;
                var products = db.Products.Filter(userId).ToList().Select(Mapper.Map<ProductViewModel>).ToList();
                return View(products);
            }
        }

        public ActionResult CreateProduct(int shop) {
            var userId = User.Identity.GetUserId();
            using (var db = new UwtContext()) {
                var myShop = db.Shops.Filter(userId).FirstOrDefault(s => s.Id == shop);
                if (myShop == null) {
                    return HttpNotFound();
                }
                ViewBag.ShopName = myShop.Name;
                ViewBag.ShopId = myShop.Id;
                ViewBag.Categories = db.Categories.Filter(userId).ToList().Select(c => new SelectListItem {Text = c.Name, Value = c.Id.ToString()});
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct([Bind(Exclude = "Shop,Categories")] ProductViewModel model, int shop, HttpPostedFileBase image, string[] categories) {
            var userId = User.Identity.GetUserId();
            if (ModelState.IsValid) {
                var product = Mapper.Map<Product>(model);
                using (var db = new UwtContext()) {
                    var myShop = db.Shops.Filter(userId).FirstOrDefault(s => s.Id == shop);
                    if (myShop == null) {
                        return HttpNotFound();
                    }
                    product.Shop = myShop;
                    product.Image = image.AddUploadedImage(Server, db.Users.FirstOrDefault(u => u.Id == userId));
                    product.Categories = categories.Select(int.Parse).Select(cid => db.Categories.IncludeAll().Filter(userId).FirstOrDefault(c => c.Id == cid)).ToList();
                    product.Views = 0;
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Products", "Merchant", new { shop = myShop.Id });
                }
            }
            using (var db = new UwtContext()) {
                var myShop = db.Shops.Filter(userId).FirstOrDefault(s => s.Id == shop);
                if (myShop == null) {
                    return HttpNotFound();
                }
                ViewBag.ShopName = myShop.Name;
                ViewBag.ShopId = myShop.Id;
                ViewBag.Categories = db.Categories.Filter(userId).ToList().Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            }
            return View(model);
        }
    }
}