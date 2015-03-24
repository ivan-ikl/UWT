using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace UWT.Models {

    public class Category {
        
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public virtual Image Image { get; set; }

        public virtual List<Advert> Adverts { get; set; }

    }

}
