using System.ComponentModel.DataAnnotations;
using UWT.Web.Interfaces;

namespace UWT.Web.Models {
    public class CategoryViewModel : IThumbnail {

        public int Id { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        [Display(Name = "Naziv kategorije")]
        public string Name { get; set; }

        public int Products { get; set; }

        public ShopViewModel Shop { get; set; }

        public string Image { get; set; }

        public string Title { get { return Name; } }

        public string Description { get { return "Broj proizvoda: " + Products; } }

    }
}