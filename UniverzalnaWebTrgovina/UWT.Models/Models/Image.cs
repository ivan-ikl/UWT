using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UWT.Models.Interfaces;

namespace UWT.Models {

    public class Image : IUserOwned {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [InverseProperty("Logo")]
        public virtual List<PageStyle> PageStyleLogos { get; set; }

        [InverseProperty("BackgroundImage")]
        public virtual List<PageStyle> PageStyleBackgrounds { get; set; }

        [InverseProperty("NavImage")]
        public virtual List<PageStyle> PageStyleNavImages { get; set; }

        [InverseProperty("FooterImage")]
        public virtual List<PageStyle> PageStyleFooterImages { get; set; }

        public virtual List<Category> Categories { get; set; }

        public virtual Product Advert { get; set; }

        [InverseProperty("ProfileImages")]
        public virtual User UserProfile { get; set; }

        [InverseProperty("OwnedImages")]
        public virtual User Owner { get; set; }

    }

}
