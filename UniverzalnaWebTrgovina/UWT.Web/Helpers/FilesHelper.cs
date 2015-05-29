using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UWT.Models;

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
                filename = Guid.NewGuid() + "." + extension;
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
        /// <param name="imageId">If the file was uploaded earlyer, the uploaded file's filename</param>
        /// <param name="uploadedFilename"></param>
        /// <returns>New image filename</returns>
        public static string SaveUploadedImage(this HttpPostedFileBase image, HttpServerUtilityBase server, string uploadedFilename = null)
        {
            if (image == null)
            {
                // The image was probably uploaded earlier
                return uploadedFilename;
            }
            string filename;
            var basePath = server.MapPath("~/Content/Images");
            var path = GenerateFilename(basePath, "jpg", out filename);
            image.SaveAs(path);
            return filename;
        }

        public static Image AddUploadedImage(this UwtContext db, HttpPostedFileBase image, HttpServerUtilityBase server, string userId)
        {
            if (image == null || image.ContentLength == 0)
            {
                return null;
            }
            var img = new Image
            {
                DateCreated = DateTime.UtcNow, 
                Path = SaveUploadedImage(image, server) , 
                Owner = db.Users.FirstOrDefault(u => u.Id == userId)            
            };
            db.Images.Add(img);
            return img;
        }

        public static Image AddUploadedImage(this HttpPostedFileBase image, HttpServerUtilityBase server, User user)
        {
            var img = new Image
            {
                DateCreated = DateTime.UtcNow,
                Path = SaveUploadedImage(image, server),
                Owner = user
            };
            return img;
        }

        public static Image CreateUserImage(this UwtContext db, HttpPostedFileBase image, HttpServerUtilityBase server)
        {
            if (image == null || image.ContentLength == 0)
            {
                // Use default image
                return db.Images.FirstOrDefault(i => i.Path == DefaultProfileImage);
            }
            return new Image {DateCreated = DateTime.UtcNow, Path = image.SaveUploadedImage(server)};
        }

        public static Image CreateUserImage(this UwtContext db, HttpPostedFileBase newImage, HttpServerUtilityBase server, User user)
        {
            if (newImage != null)
            {
                var image = db.CreateUserImage(newImage, server);
                image.Owner = user;
                image.UserProfile = user;
                return image;
            }
            return db.Images.FirstOrDefault(i => i.Path == DefaultProfileImage);
        }

        public static string SaveUploadedLayout(this HttpPostedFileBase layout, HttpServerUtilityBase server, string uploadedFilename = null) {
            if (layout == null) {
                // The image was probably uploaded earlier
                return uploadedFilename;
            }
            string filename;
            var basePath = server.MapPath("~/Views/Shared/PageLayouts");
            var path = GenerateFilename(basePath, "cshtml", out filename);
            layout.SaveAs(path);                                                
            return filename;
        }

    }

}