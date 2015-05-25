using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UWT.Web.Models {
    public class UserViewModel {
        
        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public bool Blocked { get; set; }

        public string ProfileImage { get; set; }

    }
}