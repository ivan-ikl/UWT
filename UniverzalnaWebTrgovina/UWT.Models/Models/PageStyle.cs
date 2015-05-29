using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UWT.Models.Interfaces;

namespace UWT.Models {
    
    public class PageStyle : IUserOwned {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ForegroundColor { get; set; }

        [Required]
        public string BackgroundColor { get; set; }

        [Required]
        public string NavColor { get; set; }

        [Required]
        public string SheetColor { get; set; }

        public virtual List<Shop> Shops { get; set; }

        [Required]
        public virtual User Owner { get; set; }

        [Required]
        public virtual DateTime DateCreated { get; set; }

        [Required, InverseProperty("PageStyleLogos")]
        public virtual Image Logo { get; set; }

        [InverseProperty("PageStyleBackgrounds")]
        public virtual Image BackgroundImage { get; set; }

        [InverseProperty("PageStyleNavImages")]
        public virtual Image NavImage { get; set; }

        [InverseProperty("PageStyleFooterImages")]
        public virtual Image FooterImage { get; set; }

    }

}
