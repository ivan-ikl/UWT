using System.ComponentModel.DataAnnotations;
using UWT.Models.Interfaces;

namespace UWT.Models {
    
    public class BasketItem : IPricing {

        [Key]
        public int Id { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public virtual Basket Basket { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        public double DiscountedFrom { get; set; }
    
    }

}
