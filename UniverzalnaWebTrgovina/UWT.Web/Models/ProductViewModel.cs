using System;
using System.ComponentModel.DataAnnotations;
using UWT.Web.Interfaces;

namespace UWT.Web.Models {
    public class ProductViewModel : IThumbnail {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Naziv")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Tagovi")]
        public string Tags { get; set; }

        [Required]
        [Display(Name = "Jedinična cijena")]
        public double UnitPrice { get; set; }

        [Display(Name = "Broj pogleda")]
        public int Views { get; set; }

        [Display(Name = "Dostupna količina")]
        public int Count { get; set; }

        public virtual ShopViewModel Shop { get; set; }

        public string Image { get; set; }

        public string[] Categories { get; set; }

    }
}