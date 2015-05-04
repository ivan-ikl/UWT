using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace UWT.Models {
    
    public class Message {

        [Key]
        public long Id { get; set; }

        [Required]
        public DateTime DateSent { get; set; }

        [Required]
        public DateTime DateRecieved { get; set; }

        [Required]
        public string Text { get; set; }

        [Required, InverseProperty("MessagesRecieved")]
        public virtual User Reciever { get; set; }

        [InverseProperty("MessagesSent")]
        public virtual User Sender { get; set; }

        public virtual Product Product { get; set; }

    }

}
