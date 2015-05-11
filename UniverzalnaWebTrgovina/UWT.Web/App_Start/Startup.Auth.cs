using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using UWT.Models;

namespace UWT.Web {
    
    public partial class Startup {

        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(UWTContext.Create);
            app.CreatePerOwinContext<UwtUserManager>(UwtUserManager.Create);
            app.CreatePerOwinContext<UwtSignInManager>(UwtSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UwtUserManager, User>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // app.UseFacebookAuthentication(appId: "", appSecret: "");
            // app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions() { ClientId = "", ClientSecret = "" });
            // app.UseMicrosoftAccountAuthentication(clientId: "", clientSecret: "");

        }

    }

}