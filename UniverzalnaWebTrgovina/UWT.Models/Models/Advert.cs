using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace UWT.Models {

    public class Advert {

        [Key]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public virtual Shop Shop { get; set; }

        [Required]
        public virtual Image Image { get; set; }

        public virtual List<Order> Orders { get; set; }

        public virtual List<Category> Categories { get; set; }
    
    }

}
