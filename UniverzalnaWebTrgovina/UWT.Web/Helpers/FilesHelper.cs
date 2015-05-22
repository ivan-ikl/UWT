using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace UWT.Web.Helpers {
    public static class FilesHelper
    {
        public const string DefaultProfileImage = "User.png";

        /// <summary>
        /// Generates a new filename
        /// </summary>
        /// <param name="basePath">Folder in which the new filename is generated</param>
        /// <param name="extension">Filename extension</param>
        /// <param name="filename">Returns the generated filename</param>
        /// <returns>Whole path with the new filename</returns>
        public static string GenerateFilename(string basePath, string extension, out string filename)
        {
            while (true)
            {
                filename = Guid.NewGuid() + extension;
                var path = Path.Combine(basePath, filename);
                if (!File.Exists(path))
                {
                    return path;                    
                }
            }
        }


        /// <summary>
        /// Saves the uploaded image with a new filename
        /// </summary>
        /// <param name="image">Posted file</param>
        /// <param name="server"></param>
        /// <returns>New image filename</returns>
        public static string SaveUploadedImage(this HttpPostedFileBase image, HttpServerUtilityBase server)
        {
            string filename;
            string basePath = server.MapPath("~/Content/Images");
            var path = GenerateFilename(basePath, "jpg", out filename);
            image.SaveAs(path);
            return filename;
        }

    }

}