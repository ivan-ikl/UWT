using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml;
using Windows.Storage;
using UWT.Portable.Models;

namespace UWT.App {
    public static class Context {
        private static UwtContext _uwtContext;

        public static UwtContext UwtContext
        {
            get { return _uwtContext ?? (_uwtContext = LoadContext()); }
            set { _uwtContext = value; }
        }

        public static UwtContext LoadContext()
        {
            var serializer = new DataContractSerializer(typeof(UwtContext));
            return (UwtContext)serializer.ReadObject(XmlReader.Create("Assets/Context.xml"));
        }

        public static async Task<bool> SaveContext()
        {
            try
            {
                var serializer = new DataContractSerializer(typeof (UwtContext));
                var folder = await ApplicationData.Current.LocalFolder.GetFolderAsync("Assets");
                var file = await folder.CreateFileAsync("Context.xml", CreationCollisionOption.ReplaceExisting);
                using (var stream = await file.OpenStreamForWriteAsync())
                {
                    serializer.WriteObject(XmlWriter.Create(stream), UwtContext);
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
