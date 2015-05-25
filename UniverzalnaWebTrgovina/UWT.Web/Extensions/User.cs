using System.Linq;
using UWT.Models;

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

    }
}