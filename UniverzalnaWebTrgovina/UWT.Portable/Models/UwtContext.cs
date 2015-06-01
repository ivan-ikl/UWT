using System.Runtime.Serialization;

namespace UWT.Portable.Models
{
    [DataContract]
    public class UwtContext
    {
        [DataMember]
        public Shop[] Shops { get; set; }
    }
}
