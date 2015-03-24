using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace UWT.Models {
    
    public class Invoice {

        [Key]
        public long Id { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public virtual Basket Basket { get; set; }

    }

}
