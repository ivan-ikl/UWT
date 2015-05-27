using System;
using System.ComponentModel.DataAnnotations;

namespace UWT.Web.Models {
    public class ShopViewModel {

        public int Id { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Unesite valjanu email adresu!")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Broj telefona mora biti valjan!")]
        public string Phone { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public UserViewModel Owner { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public int PageStyle { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public int PageLayout { get; set; }
    }
}