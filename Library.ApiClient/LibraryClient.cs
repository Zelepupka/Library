using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace Library.ApiClient
{
    public static class LibraryClient
    {
        public static async Task<HttpClient> GetAppClientAsync()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "api1"
            });

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error);
            }
            client.SetBearerToken(tokenResponse.AccessToken);

            return client;
        }

        public static async Task<HttpClient> GetUserClientAsync()
        {

            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }

            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = disco.TokenEndpoint,
                ClientId = "user",
                ClientSecret = "userSecret",
                UserName = "ConsoleUser@mail.ru",
                Password = "Console1!"
            });

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error);
            }
            client.SetBearerToken(tokenResponse.AccessToken);

            return client;
        }
    }
}