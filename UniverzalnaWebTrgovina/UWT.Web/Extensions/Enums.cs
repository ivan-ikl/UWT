using UWT.Web.Controllers;

namespace UWT.Web.Extensions {
    public static class Enums {

        public static string ToMessageString(this ManageController.ManageMessageId? message)
        {
            return message == ManageController.ManageMessageId.ChangePasswordSuccess ? "Lozinka je uspješno promijenjena."
                : message == ManageController.ManageMessageId.SetPasswordSuccess ? "Lozinka je postavljena."
                : message == ManageController.ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageController.ManageMessageId.Error ? "Došlo je do pogreške."
                : message == ManageController.ManageMessageId.AddPhoneSuccess ? "Telefonski broj je dodan"
                : message == ManageController.ManageMessageId.RemovePhoneSuccess ? "Telefonski broj je poništen"
                : "";
        }

    }
}