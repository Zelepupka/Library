using System.Collections.Generic;
using IdentityServer4.Models;

namespace Library.Web
{
    public class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("bookApi", "Book API"),
                new ApiScope("userApi","User API")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "userApi",
                    DisplayName = "User API",
                    ApiSecrets = new List<Secret>
                    {
                        new Secret("user".Sha256())
                    },
                    Scopes = new List<string>
                    {
                        "UserRating"
                    }
                }
            };
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                },
                new Client()
                {
                    ClientId = "user",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets =
                    {
                      new Secret("userSecret".Sha256())
                    },
                    AllowedScopes = {"userApi"}
                }
            };
    }
}