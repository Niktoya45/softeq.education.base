using IdentityServer4.Models;
using IdentityServer4;

namespace TrialsSystem.IdentityService.Infrastructure
{
    public static class IdentityConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("identity_api", "Identity API"),
                new ApiScope("gateway_api", "Gateway API")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "web",
                    ClientSecrets = { new Secret("708e567a-38b7-44bf-aa72-a087c34b5cc4".Sha256()) },

                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,

                    RedirectUris = { "https://localhost:7140", 
                                     "https://localhost:7140/signin-oidc",
                                     "https://localhost:7080",
                                     "http://localhost:5235",
                                     "https://localhost:8080",
                                     "http://localhost:3000"},

                    PostLogoutRedirectUris = { "https://localhost:7140", 
                                    "https://localhost:7140/signout-callback-oidc",
                                     "https://localhost:7080",
                                     "http://localhost:5235",
                                     "https://localhost:8080",
                                     "http://localhost:3000" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "identity_api",
                        "gateway_api"
                    },

                    AlwaysSendClientClaims = true
                },

                new Client
                {
                    ClientId = "mobile_ios",
                    ClientSecrets = { new Secret("e8cafe02-2c49-4e2c-bb17-2c7d69a8ac63".Sha256()) },

                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = false,

                    RedirectUris = { "https://localhost:7140",
                                     "https://localhost:7140/signin-oidc",
                                     "https://localhost:7080",
                                     "http://localhost:5235",
                                     "https://localhost:8080",
                                     "http://localhost:3000" },

                    PostLogoutRedirectUris = { "https://localhost:7140", 
                        "https://localhost:7140/signout-callback-oidc",
                                     "https://localhost:7080",
                                     "http://localhost:5235",
                                     "https://localhost:8080",
                                     "http://localhost:3000" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "identity_api",
                        "gateway_api"
                    },

                    AlwaysSendClientClaims = true
                },
                
                new Client
                {
                    ClientId = "mobile_android",
                    ClientSecrets = { new Secret("f65347ea-2b2f-4bae-9a68-83625e75e523".Sha256()) },

                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = false,

                    RedirectUris = { "https://localhost:7140", 
                                     "https://localhost:7140/signin-oidc",
                                     "https://localhost:7080",
                                     "http://localhost:5235",
                                     "https://localhost:8080",
                                     "http://localhost:3000" },

                    PostLogoutRedirectUris = { "https://localhost:7140", 
                        "https://localhost:7140/signout-callback-oidc",
                                     "https://localhost:7080",
                                     "http://localhost:5235",
                                     "https://localhost:8080",
                                     "http://localhost:3000" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "identity_api",
                        "gateway_api"
                    },

                    AlwaysSendClientClaims = true
                }
            };
    }
}
