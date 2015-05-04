using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UWT.Models.Interfaces;

namespace UWT.Models {

    public class PageLayout : IUserOwned {

        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Layout { get; set; }

        public virtual List<PageStyle> PageStyles { get; set; }

        [Required]
        public virtual User Owner { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

    }

}
