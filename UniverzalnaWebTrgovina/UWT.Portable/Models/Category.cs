using System;
using System.Runtime.Serialization;

namespace UWT.Portable.Models {
    [DataContract]
    public class Category {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Product[] Products { get; set; } 

        [DataMember]
        public string Image { get; set; }

        public string ImageFilename {
            get { return "Assets/" + Image; }
        }

    }
}
