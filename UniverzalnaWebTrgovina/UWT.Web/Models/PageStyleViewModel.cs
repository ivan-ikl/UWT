using System.ComponentModel.DataAnnotations;

namespace UWT.Web.Models {
    public class PageStyleViewModel {

        public int Id { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        [Display(Name = "Naziv")]
        public string Name { get; set; }

        [Display(Name = "Boja teksta")]
        [Required(ErrorMessage = "Polje je obavezno!")]
        public string ForegroundColor { get; set; }

        [Display(Name = "Boja pozadine")]
        [Required(ErrorMessage = "Polje je obavezno!")]
        public string BackgroundColor { get; set; }

        [Display(Name = "Boja izbornika")]
        [Required(ErrorMessage = "Polje je obavezno!")]
        public string NavColor { get; set; }

        [Display(Name = "Boja listova")]
        [Required(ErrorMessage = "Polje je obavezno!")]
        public string SheetColor { get; set; }

        public UserViewModel Owner { get; set; }

        public string Logo { get; set; }

        public string BackgroundImage { get; set; }

        public virtual string NavImage { get; set; }

        public virtual string FooterImage { get; set; }

    }
}
