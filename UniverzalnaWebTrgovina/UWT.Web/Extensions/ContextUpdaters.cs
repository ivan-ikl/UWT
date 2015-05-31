using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using UWT.Models;
using UWT.Models.Extensions;
using UWT.Web.Helpers;
using UWT.Web.Models;
using WebGrease.Css.Extensions;

namespace UWT.Web.Extensions {
    public static class ContextUpdaters {

        public static void Update(this PageStyle o, PageStyleViewModel model, HttpPostedFileBase imglogo,
            HttpPostedFileBase imgbackground, HttpPostedFileBase imgnav, HttpPostedFileBase imgfooter, HttpServerUtilityBase server)
        {
            o.BackgroundColor = model.BackgroundColor;
            o.ForegroundColor = model.ForegroundColor;
            o.NavColor = model.NavColor;
            o.SheetColor = model.SheetColor;
            o.Name = model.Name;

            if (imglogo != null) o.Logo = imglogo.AddUploadedImage(server, o.Owner);
            
            if (imgbackground != null) o.BackgroundImage = imgbackground.AddUploadedImage(server, o.Owner);
            
            if (imgnav != null) o.NavImage = imgnav.AddUploadedImage(server, o.Owner);
            
            if (imgfooter != null) o.FooterImage = imgfooter.AddUploadedImage(server, o.Owner);
        }

        public static void Update(this Shop shop, ShopViewModel model, PageStyle style, PageLayout layout)
        {
            shop.Address = model.Address;
            shop.Email = model.Email;
            shop.Name = model.Name;
            shop.Phone = model.Phone;
            if (style != null) shop.PageStyle = style;
            if (layout != null) shop.PageLayout = layout;
        }

        public static bool UpdateDiscounts(this UwtContext db, ShopDiscountModel model, string userId)
        {
            var shop = db.Shops.Filter(userId).IncludeAll().FirstOrDefault(s => s.Id == model.Id);
            if (shop == null) return false;

            shop.Discount = (double) model.Discount/100;

            model.Categories.ForEach(modelCategory => {
                var category = db.Categories.Filter(userId, shop.Id).IncludeAll().FirstOrDefault(c => c.Id == modelCategory.Id);
                if (category != null) category.Discount = (double) modelCategory.Discount/100;
            });

            model.Products.ForEach(modelProduct => {
                var product = db.Products.Filter(userId, shop.Id).IncludeAll().FirstOrDefault(c => c.Id == modelProduct.Id);
                if (product != null) product.Discount = (double) modelProduct.Discount/100;
            });
            return true;
        }

    }
}