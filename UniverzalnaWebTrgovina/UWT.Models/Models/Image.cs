using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UWT.Models.Interfaces;

namespace UWT.Models {

    public class Image : IUserOwned {

        [Key]
        public long Id { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [InverseProperty("Logo")]
        public virtual PageStyle PageStyleLogo { get; set; }

        [InverseProperty("BackgroundImage")]
        public virtual PageStyle PageStyleBackground { get; set; }

        public virtual Category Category { get; set; }

        public virtual Product Advert { get; set; }

        [InverseProperty("ProfileImages")]
        public virtual User UserProfile { get; set; }

        [InverseProperty("OwnedImages")]
        public virtual User Owner { get; set; }

    }

}
