using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UWT.Models.Interfaces;
using UWT.Models.Models;

namespace UWT.Models {

    public class Product : IShopMember, IPricing, IImageContainer {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string Tags { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [Required]
        public int Views { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public virtual Shop Shop { get; set; }

        [Required]
        public virtual Image Image { get; set; }

        public double Discount { get; set; }

        public virtual List<BasketItem> Orders { get; set; }

        public virtual List<Category> Categories { get; set; }

        public virtual List<Message> Messages { get; set; }

        public virtual List<Search> Searches { get; set; } 

    }

}
