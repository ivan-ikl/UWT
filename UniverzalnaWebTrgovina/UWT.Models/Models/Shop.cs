using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace UWT.Models {
    public class Shop {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateOpened { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string Address { get; set; }

        [Required]
        public virtual User User { get; set; }

        public virtual PageStyle PageStyle { get; set; }

        public virtual List<Advert> Adverts { get; set; }

        public virtual List<Category> Categories { get; set; }

    }
}
