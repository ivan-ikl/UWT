using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UWT.Models.Interfaces;

namespace UWT.Models {

    public class Category : IShopMember, IImageContainer {
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public virtual Image Image { get; set; }

        [Required]
        public virtual Shop Shop { get; set; }

        public virtual List<Product> Products { get; set; }

    }

}
