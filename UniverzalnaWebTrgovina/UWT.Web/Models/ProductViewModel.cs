using System;
using System.ComponentModel.DataAnnotations;
using UWT.Web.Interfaces;

namespace UWT.Web.Models {
    public class ProductViewModel : IThumbnail {

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Tags { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        public int Views { get; set; }

        public int Count { get; set; }

        public virtual ShopViewModel Shop { get; set; }

        public string Image { get; set; }

    }
}