using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWT.Models.Interfaces;

namespace UWT.Models.Models {
    
    public class Search : IShopMember, IUserOwned {

        [Key]
        public long Id { get; set; }

        public virtual User Owner { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public virtual Shop Shop { get; set; }

        [Required]
        public string SearchText { get; set; }

        public virtual List<Product> ProductsFound { get; set; }

    }

}
