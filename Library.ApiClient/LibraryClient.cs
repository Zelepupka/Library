using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace Library.ApiClient
{
    public static class LibraryClient
    {
        public static async Task<HttpClient> GetAppClientAsync(string clientId, string clientSecret, string scope, string url)
        {
            var httpHandler = new HttpClientHandler
            {
                Proxy = new WebProxy("192.168.7.100:8080")
                {
                    BypassProxyOnLocal = true,
                    UseDefaultCredentials = true,
                },
            };

            var client = new HttpClient(handler: httpHandler, disposeHandler: true);

            var disco = await client.GetDiscoveryDocumentAsync(url);
            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }
       
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = clientId,
                ClientSecret = clientSecret,
                Scope = scope
            });

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error);
            }
            client.SetBearerToken(tokenResponse.AccessToken);

            return client;
        }

        public static async Task<HttpClient> GetUserClientAsync(string clientId, string clientSecret, string username, string password, string url)
        {

            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(url);
            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }

            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = disco.TokenEndpoint,
                ClientId = clientId,
                ClientSecret = clientSecret,
                UserName = username,
                Password = password
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