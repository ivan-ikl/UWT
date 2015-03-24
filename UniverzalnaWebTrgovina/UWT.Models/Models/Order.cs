using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace UWT.Models {
    
    public class Order {

        [Key]
        public long Id { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public virtual Basket Basket { get; set; }

        [Required]
        public virtual Advert Advert { get; set; }

        [Required]
        public double Price { get; set; }
    
    }

}
