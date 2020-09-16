using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Models.AuthViewModels
{
    public class SendEmailVerificationViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}