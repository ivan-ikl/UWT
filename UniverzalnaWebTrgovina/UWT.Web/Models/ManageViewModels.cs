using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace UWT.Web.Models
{
    public class IndexViewModel
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [Display(Name = "Ime")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [Display(Name = "Prezime")]
        public string Surname { get; set; }

        [Display(Name = "Adresa (za dostavu)")]
        public string Address { get; set; }

        public string ProfileImage { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [Phone(ErrorMessage = "Unesite valjani telefonski broj!")]
        [Display(Name = "Telefonski broj")]
        public string PhoneNumber { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Polje je obavezno")]
        [DataType(DataType.Password)]
        [Display(Name = "Stara lozinka")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(100, ErrorMessage = "{0} mora imati najmanje {2} znakova.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova lozinka")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrda nove lozinke")]
        [Compare("NewPassword", ErrorMessage = "Lozinke nisu jednake.")]
        public string ConfirmPassword { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }

}
