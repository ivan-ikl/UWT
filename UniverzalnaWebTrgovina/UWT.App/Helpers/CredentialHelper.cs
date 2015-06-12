using System;
using System.Diagnostics;
using System.Linq;
using Windows.Security.Credentials;

namespace UWT.App.Helpers {
    public class CredentialHelper {
        
        public string Password { get; set; }

        public string Username { get; set; }

        private PasswordVault Vault { get; set; }

        public CredentialHelper()
        {
            Vault = new PasswordVault();
            var list = Vault.RetrieveAll();
            if (!list.Any())
            {
                Vault.Add(new PasswordCredential("UwtResource", "", ""));
                list = Vault.RetrieveAll();
            }
            Username = list.FirstOrDefault().UserName;
            Password = list.FirstOrDefault().Password;
        }

        public void SaveChanges()
        {
            try
            {
                Vault.Remove(Vault.RetrieveAll().First());
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            Vault.Add(new PasswordCredential("UwtResource", Username, Password));
        } 
    }
}
