using System.Runtime.Serialization;

namespace UWT.Portable.Models
{
    [DataContract]
    public class Shop
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Category[] Categories { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}