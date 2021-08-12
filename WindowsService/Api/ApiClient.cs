using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace WindowsService.Api
{
    public class ApiClient
    {
        public static async Task<HttpClient> GetClient(string clientId, string clientSecret, string scope, string url)
        {
            var  client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001/");
            if (disco.IsError)
            {
                EventLog eventLog = new EventLog();
                eventLog.Source = "New Source";
                eventLog.WriteEntry(disco.Error, EventLogEntryType.Warning, 101, 1);
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
    }
}