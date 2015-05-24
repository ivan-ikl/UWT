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

    }

}