using UWT.Web.Interfaces;

namespace UWT.Web.Models {
    public class CategoryViewModel : IThumbnail {

        public long Id { get; set; }

        public string Name { get; set; }

        public int Products { get; set; }

        public ShopViewModel Shop { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get { return Name; } }

        public string Description { get { return "Broj proizvoda: " + Products; } }

    }
}