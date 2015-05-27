using System.Collections.Generic;
using System.Web.WebSockets;
using AutoMapper;
using UWT.Models;
using UWT.Web.Helpers;
using UWT.Web.Models;

namespace UWT.Web.Extensions {

    public static class Converters {

        public static User ToUser(this RegisterViewModel model, Image profileImage)
        {
            var user = Mapper.Map<User>(model);
            user.ProfileImages = new List<Image> {profileImage};
            if (profileImage != null && profileImage.Path != FilesHelper.DefaultProfileImage)
            {
                user.OwnedImages = new List<Image> {profileImage};
            }
            return user;
        }

        public static IndexViewModel ToIndexViewModel(this User model)
        {
            return Mapper.Map<IndexViewModel>(model);
        }

        public static User ToUser(this IndexViewModel model, Image newProfileImage)
        {
            var user = Mapper.Map<User>(model);
            if (newProfileImage != null) {
                user.ProfileImages.Add(newProfileImage);
                user.OwnedImages.Add(newProfileImage);
            }
            return user;            
        }

        public static string Source(this Image image)
        {
            if (image != null)
            {
                return "~/Content/Images/" + image.Path;
            }
            return null;
        }

    }

}