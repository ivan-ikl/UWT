using System.ComponentModel.DataAnnotations;

namespace UWT.Web.Models {
    public class PageStyleViewModel {

        public int Id { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        public string ForegroundColor { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        public string BackgroundColor { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        public string NavColor { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        public string SheetColor { get; set; }

        public UserViewModel Owner { get; set; }

        public string Logo { get; set; }

        public string BackgroundImage { get; set; }

        public virtual string NavImage { get; set; }

        public virtual string FooterImage { get; set; }

    }
}
