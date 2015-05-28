using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UWT.Models.Interfaces;

namespace UWT.Models.Models {
    
    public class Search : IShopMember, IUserOwned {

        [Key]
        public int Id { get; set; }

        public virtual User Owner { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public virtual Shop Shop { get; set; }

        [Required]
        public string SearchText { get; set; }

        public virtual List<Product> ProductsFound { get; set; }

    }

}
