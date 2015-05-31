using System;
using System.ComponentModel.DataAnnotations;

namespace UWT.Web.Models {
    public class ShopViewModel {

        public int Id { get; set; }

        [Display(Name = "Naziv trgovine")]
        [Required(ErrorMessage = "Polje je obavezno")]
        public string Name { get; set; }

        [Display(Name = "Email trgovine")]
        [EmailAddress(ErrorMessage = "Unesite valjanu email adresu!")]
        public string Email { get; set; }

        [Display(Name = "Telefonski broj")]
        [Phone(ErrorMessage = "Broj telefona mora biti valjan!")]
        public string Phone { get; set; }

        [Display(Name = "Adresa trgovine")]
        public string Address { get; set; }

        [Display(Name = "Otvorenje")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Stil stranice")]
        [Required(ErrorMessage = "Polje je obavezno")]
        public int PageStyle { get; set; }

        [Display(Name = "Raspored stranice")]
        [Required(ErrorMessage = "Polje je obavezno")]
        public int PageLayout { get; set; }
    }
}