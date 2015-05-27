using System;
using System.ComponentModel.DataAnnotations;

namespace UWT.Web.Models
{
    public class PageLayoutViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [Display(Name = "Naziv")]
        public string Name { get; set; }

        public string Layout { get; set; }

        [Display(Name = "Izrađeno")]
        public DateTime DateCreated { get; set; }
    }
}