﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace IdentityServer.Models.AuthViewModels
{
    public class LoginViewModel
    {
        [Required] public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
        public string StatusMessage { get; set; }

        public IEnumerable<AuthenticationScheme> ExternalProviders { get; set; }
    }
}