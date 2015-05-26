using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UWT.Models;

namespace UWT.Web.Models {
    public class UserViewModel {
        
        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public bool Blocked { get; set; }

        public string ProfileImage { get; set; }

    }

    public class PageLayoutViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [Display(Name = "Naziv")]
        public string Name { get; set; }

        public string Layout { get; set; }

        [Display(Name = "Broj izvedenih stilova")]
        public virtual int PageStyles { get; set; }

        [Display(Name = "Izrađeno")]
        public DateTime DateCreated { get; set; }
    }
}