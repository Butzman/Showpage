using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Configuration
    {
        
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        public static IEnumerable<ApiScope> GetApis() =>
            new List<ApiScope> {new ApiScope("Api_CodersShop")};
        
        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "react_client",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris = {"http://localhost:3000/callback"},
                    PostLogoutRedirectUris = {"http://localhost:3000/signed-out"},
                    AllowedCorsOrigins = {"http://localhost:3000"},

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "Api_CodersShop",
                    },

                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                }, 
                new Client
                {
                    ClientId = "blazor_client",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    
                    RedirectUris = {"https://localhost:3001/authentication/login-callback"},
                    PostLogoutRedirectUris = {"https://localhost:3001/"},
                    AllowedCorsOrigins = {"https://localhost:3001"},

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "Api_CodersShop",
                    },

                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                },
            };
    }
}