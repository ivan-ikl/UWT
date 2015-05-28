using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UWT.Models.Interfaces;

namespace UWT.Models {
    
    public class Basket : IUserOwned {

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// After the order is confirmed, rejected or has expired, the basket will be closed.
        /// Once a basket has been closed, its orders are locked.
        /// </summary>
        [Required]
        public DateTime DateClosed { get; set; }

        [Required]
        public virtual User Owner { get; set; }

        public virtual List<BasketItem> BasketItems { get; set; }

        /// <summary>
        /// An invoice gets generated when the user confirms his order
        /// </summary>
        public virtual Invoice Invoice { get; set; }
    
    }

}
