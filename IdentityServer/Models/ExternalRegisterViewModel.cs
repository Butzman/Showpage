using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
    public class ExternalRegisterViewModel
    {
        [RegularExpression(@"^\S*$", ErrorMessage = "Der Benutzername '{0}' ist ungültig und darf nur Buchstaben oder Ziffern enthalten." )]
        public string Username { get; set; }
        
        public string Email { get; set; }
        public string Provider { get; set; }
        public string ReturnUrl { get; set; }
    }
}