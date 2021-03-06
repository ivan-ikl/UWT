﻿using System;
using System.Linq;
using UWT.Models;
using UWT.Web.Models;

namespace UWT.Web.Extensions {
    public static class UserExtensions {

        public static string ProfileImage(this User user)
        {
            if (user != null && user.ProfileImages != null)
            {
                var image = user.ProfileImages.OrderByDescending(i => i.DateCreated).FirstOrDefault();
                return image != null ? image.Path : null;
            }
            return null;
        }

        public static bool IsBlocked(this User user)
        {
            return user != null && user.Blocked <= DateTime.UtcNow;
        }

        public static void Block(this User user)
        {
            if (user != null && !user.IsBlocked()) user.Blocked = DateTime.UtcNow;
        }

        public static void Unblock(this User user)
        {
            if (user != null && user.IsBlocked()) user.Blocked = DateTime.MaxValue;
        }

        public static bool IsBlocked(this LoginViewModel model)
        {
            using (var db = new UwtContext())
            {
                return db.Users.FirstOrDefault(u => u.UserName == model.Email).IsBlocked();
            }
        }

    }
}