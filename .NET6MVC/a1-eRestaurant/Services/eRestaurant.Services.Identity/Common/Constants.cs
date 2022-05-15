﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace eRestaurant.Services.Identity.Common
{

    public static class Constants
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope> {
                new ApiScope("a1eResturant", "A1 eResturant Server"),
                new ApiScope(name: "read",   displayName: "Read your data."),
                new ApiScope(name: "write",  displayName: "Write your data."),
                new ApiScope(name: "delete", displayName: "Delete your data.")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId="client",
                    ClientSecrets= { new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes={ "read", "write","profile"}
                },
                new Client
                {
                    ClientId="a1eResturant",
                    ClientSecrets= { new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris={ "https://localhost:7274/signin-oidc" },
                    PostLogoutRedirectUris={"https://localhost:7274/signout-callback-oidc" },
                    AllowedScopes=new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "a1eResturant"
                    }
                },
            };

    }

}
