using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace UWT.Models {
    
    public class Basket {

        [Key]
        public long Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// After the order is confirmed, rejected or has expired, the basket will be closed.
        /// Once a basket has been closed, its orders are locked.
        /// </summary>
        [Required]
        public DateTime DateClosed { get; set; }

        [Required]
        public virtual User User { get; set; }

        public virtual List<Order> Orders { get; set; }

        /// <summary>
        /// An invoice gets generated when the user confirms his order
        /// </summary>
        public virtual Invoice Invoice { get; set; }
    
    }

}
