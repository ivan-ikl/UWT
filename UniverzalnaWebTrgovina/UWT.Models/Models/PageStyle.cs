using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace UWT.Models {
    
    public class PageStyle {

        [Key]
        public int Id { get; set; }

        [Required]
        public string ForegroundColor { get; set; }

        [Required]
        public string BackgroundColor { get; set; }

        [Required]
        public string NavColor { get; set; }

        [Required]
        public string SheetColor { get; set; }

        [Required]
        public virtual Shop Shop { get; set; }

        [Required, InverseProperty("PageStyleLogo")]
        public virtual Image Logo { get; set; }

        [Required, InverseProperty("PageStyleBackground")]
        public virtual Image BackgroundImage { get; set; }

    }

}
