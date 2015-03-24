using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace UWT.Models {

    public class Image {

        [Key]
        public long Id { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [InverseProperty("Logo")]
        public virtual PageStyle PageStyleLogo { get; set; }

        [InverseProperty("BackgroundImage")]
        public virtual PageStyle PageStyleBackground { get; set; }

        public virtual Category Category { get; set; }

        public virtual Advert Advert { get; set; }

        public virtual User UserProfile { get; set; }

    }

}
