using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UWT.Models;
using UWT.Models.Extensions;
using UWT.Web.Models;

namespace UWT.Web.Extensions {
    public static class ShopViewModelExtensions 
    {
        public static PageStyleViewModel GetPageStyle(this ShopViewModel model)
        {
            using (var db = new UwtContext())
            {
                var pageStyle = db.PageStyles.IncludeAll().FirstOrDefault(o => o.Id == model.PageStyle);
                return Mapper.Map<PageStyleViewModel>(pageStyle);
            }
        }

        public static PageStyleViewModel GetPageLayout(this ShopViewModel model) {
            using (var db = new UwtContext()) {
                var pageLayout = db.PageLayouts.IncludeAll().FirstOrDefault(o => o.Id == model.PageLayout);
                return Mapper.Map<PageStyleViewModel>(pageLayout);
            }
        }

        public static IEnumerable<ProductViewModel> GetProducts(this ShopViewModel model)
        {
            using (var db = new UwtContext()) {
                var products = db.Products.IncludeAll().Filter(model.Id).ToList();
                return products.Select(Mapper.Map<ProductViewModel>).ToList();
            }            
        }

        public static IEnumerable<ProductViewModel> GetProducts(this IEnumerable<ShopViewModel> models)
        {
            using (var db = new UwtContext()) {
                var products = models.SelectMany(model => db.Products.IncludeAll().Filter(model.Id).ToList()).ToList();
                return products.Select(Mapper.Map<ProductViewModel>).ToList();
            }
        } 

    }
}