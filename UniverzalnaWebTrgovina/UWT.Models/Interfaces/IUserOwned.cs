using System;

namespace UWT.Models.Interfaces {

    public interface IUserOwned {

        User Owner { get; set; }

        DateTime DateCreated { get; set; }

    }

}
