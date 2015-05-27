using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UWT.Models.Interfaces;

namespace UWT.Models {
    public class Shop : IUserOwned {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string Address { get; set; }

        [Required]
        public virtual User Owner { get; set; }

        [Required]
        public virtual DateTime DateCreated { get; set; }

        [Required]
        public virtual PageStyle PageStyle { get; set; }

        [Required]
        public virtual PageLayout PageLayout { get; set; }

        public virtual List<Product> Products { get; set; }

        public virtual List<Category> Categories { get; set; }

    }
}
