using System;
using System.Runtime.Serialization;

namespace UWT.Portable.Models {

    [DataContract]
    public class Product {

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Image { get; set; }

        [DataMember]
        public double UnitPrice { get; set; }

        [DataMember]
        public int Views { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public double DiscountedPrice { get; set; }

        [DataMember]
        public int NumberSold { get; set; }

        public string ImageFilename {
            get { return "Assets/" + Image; }
        }

    }
}
