using Skoruba.Duende.IdentityServer.Shared.Configuration.Configuration.Identity;

using System.ComponentModel.DataAnnotations;

namespace Project4.STS.Identity.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
      
        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }
    }
}








