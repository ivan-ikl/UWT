using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using UWT.Portable.Models;

namespace UWT.App {
    public static class Context {
        private static UwtContext _uwtContext;

        public static UwtContext UwtContext
        {
            get
            {
                return _uwtContext ?? (_uwtContext = LoadContext());
            }
        }

        public static UwtContext LoadContext()
        {
            var serializer = new DataContractSerializer(typeof(UwtContext));
            return (UwtContext)serializer.ReadObject(XmlReader.Create("Assets/Context.xml"));
        }

    }
}
