using System;
using System.Collections.Generic;
using UWT.Models;

namespace UWT.Web.Models {
    public class BasketViewModel 
    {

        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateClosed { get; set; }

        public string OwnerId { get; set; }

        public List<BasketItemViewModel> BasketItems { get; set; }

        public int Invoice { get; set; }
    
    }

    public class BasketItemViewModel
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public virtual ProductViewModel Product { get; set; }

        public double UnitPrice { get; set; }

    }

}