using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace UWT.Models {
    public partial class User : IdentityUser {
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Address { get; set; }

        public DateTime Blocked { get; set; }

        [InverseProperty("Sender")]
        public virtual List<Message> MessagesSent { get; set; }

        [InverseProperty("Reciever")]
        public virtual List<Message> MessagesRecieved { get; set; }

        public virtual List<Shop> Shops { get; set; }

        [InverseProperty("UserProfile")]
        public virtual List<Image> ProfileImages { get; set; }

        [InverseProperty("Owner")]
        public virtual List<Image> OwnedImages { get; set; } 

        public virtual List<Basket> Baskets { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager) {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

    }

}
