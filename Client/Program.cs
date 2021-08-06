using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                Console.ReadKey();
                return;
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
                Console.WriteLine(tokenResponse.Error);
            }

            Console.WriteLine(tokenResponse.Json);
            client.SetBearerToken(tokenResponse.AccessToken);
            string bookId = "685cfd67-2c2a-428a-b07c-08d94cf24d7c";
            HttpContent http = new StringContent(bookId);
            var response = await client.PostAsync("https://localhost:5001/api/SetRating?bookId=685cfd67-2c2a-428a-b07c-08d94cf24d7c&value=3", http);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }

            //var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            //{
            //    Address = disco.TokenEndpoint,

            //    ClientId = "client",
            //    ClientSecret = "secret",
            //    Scope = "api1"
            //});

            //if (tokenResponse.IsError)
            //{   
            //    Console.WriteLine(tokenResponse.Error);
            //    Console.ReadKey();
            //    return;
            //}

            //Console.WriteLine(tokenResponse.Json);

            //var apiClient = new HttpClient();
            //apiClient.SetBearerToken(tokenResponse.AccessToken);

            //var response = await apiClient.GetAsync("https://localhost:5001/api/getbooks");
            //if (!response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine(response.StatusCode);
            //}
            //else
            //{
            //    var content = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine(content);
            //}

            Console.ReadKey();
        }
    }
}
