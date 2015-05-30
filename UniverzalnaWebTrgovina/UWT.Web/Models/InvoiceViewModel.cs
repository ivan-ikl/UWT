using System;

namespace UWT.Web.Models {
    public class InvoiceViewModel {

        public int Id { get; set; }

        public BasketViewModel Basket { get; set; }

        public DateTime DateCreated { get; set; }

    }
}